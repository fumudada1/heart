using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Customer_Customer_list : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"

    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }

    #endregion
    private const int PageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[Request["ModuleID"] + "txtSearch"] != null)
            {
                txtSearch.Text = Session[Request["ModuleID"] + "txtSearch"].ToString();
            }
            Show();
        }
    }

    private void Show()
    {
        DataLayer dl = new DataLayer();
        int totaleItems = dl.GetCustomerListCount(txtSearch.Text,"0");
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Customer_List.aspx?ModuleID=" + Request["ModuleID"] ;
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetCustomerList(txtSearch.Text,"0", PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
        Response.Redirect(String.Format("Customer_List.aspx?ModuleID={0}", Request["ModuleID"]));
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "txtSearch"] = null;
        txtSearch.Text = "";
        Response.Redirect(String.Format("Customer_List.aspx?ModuleID={0}", Request["ModuleID"]));
    }
    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        EasyDataProvide Customer = new EasyDataProvide("Customer");
        Customer.DeleteById(strID);
        Show();
    }
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        Response.Redirect("Customer_Edit.aspx?ModuleID=" + Request["ModuleID"] + "&id=" + strID);
    }
}