using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_A01Permission_Role_Edit : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"
    protected void Page_Init(object sender, EventArgs e)
    {

        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = "A02";
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }
    }

    private void show()
    {
        string RoleID = Request["ID"].ToString();
        EasyDataProvide Role = new EasyDataProvide("Role");
        DataRow row = Role.FillPlaceHolderControlsById(RoleID);
        PermissionUserControl2.permissionString = row["permission"].ToString();
        if(RoleID=="1")
        {
            roleName.ReadOnly = true;
            //btnUpdate.Visible = false;
        }
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        string RoleID = Request["ID"].ToString();
        EasyDataProvide Role = new EasyDataProvide("Role");
        Role.SetPlaceHolderFormQuest();
        Role.AddParameter("permission", PermissionUserControl2.permissionString);
        Role.UpdateById(RoleID);

        Response.Redirect("Role_list.aspx?ModuleID=A02");
    }
    protected void btnList_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role_list.aspx?ModuleID=A02");
    }
}