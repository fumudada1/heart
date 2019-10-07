using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Input_Input_Insert : System.Web.UI.Page
{
    readonly DataLayer _dl = new DataLayer();

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
            ViewState["GUID"] = Guid.NewGuid().ToString();
            ShowCustomer();
         
        }
    }

    private void ShowCustomer()
    {
        TIN.EasyDataProvide Customer = new EasyDataProvide("Customer");
        DataTable dt = Customer.GetAllData();
        ddlCustomer.DataTextField = "aliasName";
        ddlCustomer.DataValueField = "id";
        ddlCustomer.DataSource = dt;
        ddlCustomer.DataBind();
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide InputData = new EasyDataProvide("InputData");
        InputData.SetPlaceHolderFormQuest();
        InputData.AddParameter("customerID",ddlCustomer.SelectedValue);
        InputData.AddParameter("aliasName", ddlCustomer.SelectedItem.Text);
        InputData.Insert();
        Response.Redirect("Input_list.aspx?ModuleID=" + Request["ModuleID"] );
    }
}