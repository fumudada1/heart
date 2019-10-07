using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class i_post : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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


        }

        if (!IsPostBack)
        {
            if (Session["N02txtSearch"] != null)
            {

                txtSearch.Text = Session["N02txtSearch"].ToString();
                //Session["txtSearch"] = null;
            }
           

            Show();
        }
    }

  

    private void Show()
    {
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
        int totaleItems = dl.GetPublishListCount("N02", "", "", txtSearch.Text,strUserData, DataLayer.SortMethed.OrderByInitDate, false);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "i-post.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetPublishList("N02", "","", txtSearch.Text,strUserData, DataLayer.SortMethed.OrderByInitDate, false, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();

        lnkAddAdmin.NavigateUrl = "i-post_Insert.aspx";
       
    }

  

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        Session["N02txtSearch"] = txtSearch.Text;
        Response.Redirect(Request.Url.ToString().Replace("page", "page1"));
    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //RowDataBound Code
        }
    }

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.DeleteById(strID);
        Show();
    }
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Session["N02txtSearch"] = txtSearch.Text;
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        string page = Request["page"] ?? "1";
        Response.Redirect("i-post_Edit.aspx?ID=" + strID + "&page=" + page);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
      
        Session["N02txtSearch"] = null;

        Response.Redirect(Request.Url.ToString().Replace("page", "page1"));
    }

}