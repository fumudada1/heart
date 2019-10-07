using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class A01Permission_Account_Edit : Page
{
    private readonly EasyDataProvide _Member = new EasyDataProvide("Member");

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
            show();
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
        if(OrganizationID.Items.Count==0)
        {
            trUnit.Visible = false;
        }
        ListItem item = new ListItem("未指定", "0");
        OrganizationID.Items.Add(item);
    }

    private void show()
    {
        DataRow row = _Member.FillPlaceHolderControlsById(Request["ID"]);
        PermissionUserControl1.permissionString = row["permission"].ToString();
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        _Member.SetPlaceHolderFormQuest();
        if(!string.IsNullOrEmpty(Cpassword.Text))
        {
            _Member.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(Cpassword.Text, "MD5"));
        }
        string premissionString = PermissionUserControl1.permissionString;
        _Member.AddParameter("Permission", premissionString);
        _Member.UpdateById(Request["ID"]);
        Response.Redirect("Account_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
}