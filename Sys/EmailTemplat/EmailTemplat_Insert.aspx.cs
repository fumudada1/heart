using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_EmailTemplat_EmailTemplat_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide EmailTemplats = new EasyDataProvide("EmailTemplats");
        EmailTemplats.SetPlaceHolderFormQuest();
        EmailTemplats.Insert();
        Response.Redirect("EmailTemplat_List.aspx?ModuleID=" + Request["ModuleID"]);
    }
}