using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class i_post_Edit : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("index.aspx");

        }else{
			 string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                if (strUserData.Length > 20)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.Url.ToString());
                }
		}

        if (!IsPostBack)
        {
          
            show();


        }
    }

    private void show()
    {
        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        DataRow row = ModulePublish.FillPlaceHolderControlsById(Request["ID"]);
       
   

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        DataRow rowArticle = ModuleContents.GetSingleRow("publishID=@publishID and type is null");
        if (rowArticle != null)
        {
            article.Text = rowArticle["article"].ToString();
            ViewState["articleID"] = rowArticle["id"].ToString();
        }


      
    }



    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(article.Text))
        {
            My.WebForm.doJavaScript("alert('詳細說明不可以空白.');");
            return;
        }
        //if (shortDescription.Text.Length >=500)
        //{
        //    My.WebForm.doJavaScript("alert('簡單說明不可以超過500個字.');");
        //    return;
        //}

      

        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.SetPlaceHolderFormQuest();

        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;

        ModulePublish.AddParameter("updater", strUserData);
        
        ModulePublish.AddParameter("lastupdated", DateTime.Now.ToString());
       
        ModulePublish.UpdateById(Request["ID"]);

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("article", article.Text);
        ModuleContents.UpdateById(ViewState["articleID"].ToString());



        Response.Redirect(String.Format("i-post.aspx?&page={0}", Request["page"]));
    }

   
}