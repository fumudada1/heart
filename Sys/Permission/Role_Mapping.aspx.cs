using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_A01Permission_Role_Mapping : System.Web.UI.Page
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
        if(!IsPostBack)
        {
            Show();
        }
        
    }

    private void Show()
    {
       DataLayer dl = new DataLayer();
        DataTable dt = dl.GetRoleMapAccount(Request["RoleID"]);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EasyDataProvide RoleUserMapping = new EasyDataProvide("RoleUserMapping");
        string strID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        RoleUserMapping.DeleteById(strID);
        Show();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role_list.aspx?ModuleID=A02");
    }
}