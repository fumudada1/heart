using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_A01Permission_Role_AddAdmin : System.Web.UI.Page
{
    private DataTable TempDataTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Show();

            TempDataTable = new DataTable();
            TempDataTable.Columns.Add("ID", typeof(string));
            TempDataTable.Columns.Add("Name", typeof(String));
            TempDataTable.Columns.Add("Organization", typeof(String));
            Session["TempDataTable"] = TempDataTable;


        }
        
    }

    private void InitSession()
    {
        if (Session["TempDataTable"] != null)
        {

            TempDataTable = (DataTable)Session["TempDataTable"];

        }
        else
        {
            TempDataTable = new DataTable();
            TempDataTable.Columns.Add("ID", typeof(string));
            TempDataTable.Columns.Add("Name", typeof(String));
            TempDataTable.Columns.Add("Organization", typeof(String));
            Session["TempDataTable"] = TempDataTable;

        }
        GridView2.DataSource = TempDataTable;
        GridView2.DataBind();

    }


    private void Show()
    {
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetSelectRoleUser(Request["RoleID"]);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void BtnRight_Click(object sender, EventArgs e)
    {
        InitSession();
        foreach (GridViewRow item in GridView1.Rows)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                DataRow[] TempRow = TempDataTable.Select("id='" + GridView1.DataKeys[item.RowIndex].Value + "'");
                if (TempRow.Length == 0)
                {
                    DataRow row = TempDataTable.NewRow();
                    row["id"] = GridView1.DataKeys[item.RowIndex].Value;
                    row["Name"] = ((Label)item.FindControl("lblName")).Text;
                    row["Organization"] = ((Label)item.FindControl("lblOrganization")).Text;
                    TempDataTable.Rows.Add(row);
                }
            }

        }
        Session["TempDataTable"] = TempDataTable;
        GridView2.DataSource = TempDataTable;
        GridView2.DataBind();


    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        InitSession();
        TempDataTable.Rows.RemoveAt(e.RowIndex);
        Session["TempDataTable"] = TempDataTable;
        GridView2.DataSource = TempDataTable;
        GridView2.DataBind();
    }
    protected void BtnAdd2_Click(object sender, EventArgs e)
    {
        EasyDataProvide RoleUserMapping = new EasyDataProvide("RoleUserMapping");
        RoleUserMapping.AddParameter("roleID", Request["RoleID"]);
        foreach (GridViewRow row in GridView2.Rows)
        {


            string strID = GridView2.DataKeys[row.RowIndex].Value.ToString();
            RoleUserMapping.AddParameter("userID", strID);
            RoleUserMapping.Insert();

        }
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", "Role_Mapping.aspx?RoleID=" + Request["RoleID"]));


    }
}