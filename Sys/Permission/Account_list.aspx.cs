using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class A01Permission_Account_list : System.Web.UI.Page
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
            show();
        }
    }

    private void show()
    {

        DataLayer dataLayer = new DataLayer();
        DataTable dataTable = dataLayer.GetPermissionList();
        DataView dvAccount=new DataView(dataTable);
        dvAccount.RowFilter = "type=0";
        GridView1.DataSource = dvAccount;
        GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        if (row.Cells[0].Text == "群組")
        {
            if (id != "1")
            {
                EasyDataProvide RoleUserMapping = new EasyDataProvide("RoleUserMapping");
                RoleUserMapping.AddParameter("roleID", id);
                RoleUserMapping.Delete("roleID=" + id);
                EasyDataProvide Role = new EasyDataProvide("Role");
                Role.DeleteById(id);
            }
            else
            {
                My.WebForm.doJavaScript("alert('最高管理群組不可刪除!');");
            }


        }
        else
        {
            _Member.DeleteById(id);

        }
        show();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].Text == "群組")
            {
                ((Label)e.Row.FindControl("Label1")).Visible = false;
                HyperLink HyperLink1 = ((HyperLink)e.Row.FindControl("HyperLink1"));
                HyperLink lnkEdit = ((HyperLink)e.Row.FindControl("lnkEdit"));
                HyperLink1.Visible = true;
                e.Row.Cells[0].Style.Add("color", "green");
                lnkEdit.NavigateUrl = lnkEdit.NavigateUrl.Replace("Account_Edit.aspx", "Role_Edit.aspx");


            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        show();
    }
}