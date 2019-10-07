using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Links_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        EasyDataProvide ModuleLinks = new EasyDataProvide("ModuleLinks");
        ModuleLinks.SetPageFormQuest();
        ModuleLinks.AddParameter("publishID", Request["publishID"].ToString());
        ModuleLinks.Insert();
        string Publish = "_News_Links.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));

    }
}