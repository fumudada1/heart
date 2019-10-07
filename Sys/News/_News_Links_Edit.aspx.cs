using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Links_Edit : System.Web.UI.Page
{
    EasyDataProvide _ModuleLinks = new EasyDataProvide("ModuleLinks");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }
    }

    private void show()
    {
        _ModuleLinks.FillPageControlsById(Request["ID"]);

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

        _ModuleLinks.SetPageFormQuest();
        _ModuleLinks.UpdateById(Request["ID"]);
        string Publish = "_News_Links.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
}