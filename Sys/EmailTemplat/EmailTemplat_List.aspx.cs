using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_EmailTemplat_EmailTemplat_List : System.Web.UI.Page
{
    EasyDataProvide _EmailTemplats = new EasyDataProvide("EmailTemplats");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {
        DataTable dt = _EmailTemplats.GetAllData();
        gvList.DataSource = dt;
        gvList.DataBind();
    }
    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        _EmailTemplats.DeleteById(strID);
        Show();
    }
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        Response.Redirect("EmailTemplat_Edit.aspx?ID=" + strID + "&ModuleID=" + Request["ModuleID"]);
    }
}