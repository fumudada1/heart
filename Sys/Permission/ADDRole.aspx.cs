using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_A01Permission_ADDRole : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"
    protected void Page_Init(object sender, EventArgs e)
    {

        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        PermissionUserControl2.permissionString = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       

        EasyDataProvide Role = new EasyDataProvide("Role");
        Role.SetPlaceHolderFormQuest();
        Role.AddParameter("permission", PermissionUserControl2.permissionString);
        Role.Insert();


        Response.Redirect("Account_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
    protected void btnList_Click(object sender, EventArgs e)
    {

    }
}