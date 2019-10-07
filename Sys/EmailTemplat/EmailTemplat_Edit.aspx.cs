using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_EmailTemplat_EmailTemplat_Edit : System.Web.UI.Page
{
    EasyDataProvide _EmailTemplats = new EasyDataProvide("EmailTemplats");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {
        
        _EmailTemplats.FillPlaceHolderControlsById(Request["id"]);

    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        _EmailTemplats.SetPlaceHolderFormQuest();
        _EmailTemplats.UpdateById(Request["id"]);
        Response.Redirect("EmailTemplat_List.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + ViewState["GUID"]);
    }
}