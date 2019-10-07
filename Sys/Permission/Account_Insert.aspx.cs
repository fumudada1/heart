using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class A01Permission_Account_Insert : System.Web.UI.Page
{
    readonly EasyDataProvide _Member = new EasyDataProvide("Member");

    #region "將目前功能資料送到Master Page裡"
    protected void Page_Init(object sender, EventArgs e)
    {

        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowOrganization();
            ShowRole();
        }
    }

    private void ShowRole()
    {
        EasyDataProvide role = new EasyDataProvide("Role");
        DataTable dtRole = role.GetAllData();
        ddlRole.DataTextField = "roleName";
        ddlRole.DataValueField = "id";
        ddlRole.DataSource = dtRole;
        ddlRole.DataBind();
        if (ddlRole.Items.Count == 0)
        {
            trRole.Visible = false;
        }
    }

    private void ShowOrganization()
    {
        EasyDataProvide UnitName = new EasyDataProvide("UnitName");
        DataTable dtUnitName = UnitName.GetAllData("order by listNum");
        OrganizationID.DataTextField = "title";
        OrganizationID.DataValueField = "id";
        OrganizationID.DataSource = dtUnitName;
        OrganizationID.DataBind();
        ListItem item = new ListItem("未指定", "0");
        OrganizationID.Items.Add(item);
        if (OrganizationID.Items.Count == 1)
        {
            trUnit.Visible = false;
        }
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide Member = new EasyDataProvide("Member");
        Member.SetPlaceHolderFormQuest();
        DataRow dataRow = Member.GetSingleRow("account=@account");
        if (dataRow != null)
        {
            My.WebForm.doJavaScript("alert('帳號已使用!');");
            return;
        }
        Member.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
        string premissionString = PermissionUserControl1.permissionString;
        Member.AddParameter("Permission", premissionString);
        string userID = Member.InsertReturnValue();
        if (ddlRole.Items.Count > 0)
        {
            EasyDataProvide RoleUserMapping = new EasyDataProvide("RoleUserMapping");
            RoleUserMapping.AddParameter("roleID", ddlRole.SelectedValue);
            RoleUserMapping.AddParameter("userID", userID);
            RoleUserMapping.Insert();
        }


        Response.Redirect("Account_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
}