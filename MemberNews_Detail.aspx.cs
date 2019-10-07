using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class MemberNews_Detail : System.Web.UI.Page
{
    EasyDataProvide _ModulePublish = new EasyDataProvide("ModulePublish");
    EasyDataProvide _ModuleContents = new EasyDataProvide("ModuleContents");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show();

        }
    }
    private void Show()
    {
        DataRow rowPublish = _ModulePublish.FillPlaceHolderControlsById(Request["id"]);
        if (rowPublish==null)
        {
            Response.Redirect("index.aspx");
        }
        this.Title = " " + rowPublish["title"].ToString();

        EasyDataProvide ModuleFiles = new EasyDataProvide("ModuleFiles");
        ModuleFiles.AddParameter("publishID", Request["id"]);
        DataTable dtFile = ModuleFiles.GetData("publishID=@publishID order by listNum Asc");
        dlFile.DataSource = dtFile;
        dlFile.DataBind();

        if (dlFile.Items.Count == 0)
        {
            h2file.Visible = false;
        }

        //EasyDataProvide ModulePictures = new EasyDataProvide("ModulePictures");
        //ModulePictures.AddParameter("publishID", Request["id"]);
        //DataTable dtImages = ModulePictures.GetData("publishID=@publishID order by listNum Asc");
        //dlImages.DataSource = dtImages;
        //dlImages.DataBind();


        //EasyDataProvide ModuleLinks = new EasyDataProvide("ModuleLinks");
        //ModuleLinks.AddParameter("publishID", Request["id"]);
        //DataTable dtLinks = ModuleLinks.GetData("publishID=@publishID order by listNum Asc");
        //repLinks.DataSource = dtLinks;
        //repLinks.DataBind();



        _ModuleContents.AddParameter("publishID", Request["id"]);
        DataRow rowContent = _ModuleContents.FillContentPlaceHolderControls("publishID=@publishID and type is null");
        article.Text = rowContent["article"].ToString();

        DataTable dtReply = _ModuleContents.GetData("publishID=@publishID and type=1", "order by initDate desc");
        repReply.DataSource = dtReply;
        repReply.DataBind();

        DataLayer dl=new DataLayer();
        dl.ModulePublish_UpdateCountsPlus(Request["ID"]);

        if (!User.Identity.IsAuthenticated)
        {
            txtReply.Visible = false;
            lblMessage.Visible = true;
            btnReply.Visible = false;
            btnOpenReply.Visible = false;

        }
        else
        {
		 string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                if (strUserData.Length > 20)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.Url.ToString());
                }
				
            txtReply.Visible = true;
            lblMessage.Visible = false;
            btnReply.Visible = true;
            btnOpenReply.Visible = true;
        }
    }
    protected void btnReply_Click(object sender, EventArgs e)
    {
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["id"]);
        ModuleContents.AddParameter("articleTitle", strUserData);
        ModuleContents.AddParameter("article", txtReply.Text);
        ModuleContents.AddParameter("type", "1");
        ModuleContents.Insert();
        Response.Redirect(Request.Url.ToString());

    }
}