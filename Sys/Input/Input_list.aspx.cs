using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Input_Input_list : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 20;
    string strOrderBy = "ORDER BY payDate DESC";   //排序

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
            

            foreach (DataControlField col in gvList.Columns)
            {
                col.HeaderText = col.HeaderText.Replace("▲", "").Replace("▼", "");
                if (col.SortExpression == "payDate")
                {
                    col.HeaderText = col.HeaderText + "▼";

                }
            }

            ShowCustomer();
            ddlEnable.SelectedValue = Session[Request["ModuleID"] + "ddlEnable"] == null ? "" : Session[Request["ModuleID"] + "ddlEnable"].ToString();
            ddlCustomer.SelectedValue = Session[Request["ModuleID"] + "ddlCustomer"]==null?"": Session[Request["ModuleID"] + "ddlCustomer"].ToString();
            startDate.Text = Session[Request["ModuleID"] + "startDate"]==null?"": Session[Request["ModuleID"] + "startDate"].ToString();
            endDate.Text = Session[Request["ModuleID"] + "endDate"]==null?"":Session[Request["ModuleID"] + "endDate"].ToString();

            Show();
            lnkAddAdmin.NavigateUrl = "Input_Insert.aspx?ModuleID=" + Request["ModuleID"];
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
        ListItem item=new ListItem("全部","");
        ddlCustomer.Items.Insert(0,item);
    }

    private void Show()
    {

        int totaleItems = dl.GetInputDataListCount(ddlEnable.SelectedValue,ddlCustomer.SelectedValue,startDate.Text,endDate.Text);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Input_list.aspx?ModuleID=" + Request["ModuleID"];
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetInputDataList(ddlEnable.SelectedValue, ddlCustomer.SelectedValue,startDate.Text,endDate.Text, strOrderBy, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
  
    }

   

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Session[Request["ModuleID"] + "ddlEnable"]=ddlEnable.SelectedValue ;
        Session[Request["ModuleID"] + "ddlCustomer"]= ddlCustomer.SelectedValue;
        Session[Request["ModuleID"] + "startDate"]=startDate.Text;
        Session[Request["ModuleID"] + "endDate"]=endDate.Text;


        Response.Redirect(Request.Url.ToString().Replace("page", "page1"));
    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //RowDataBound Code
        }
    }

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        EasyDataProvide InputData = new EasyDataProvide("InputData");
        InputData.DeleteById(strID);
        Show();
    }
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
        //Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        string page = Request["page"] ?? "1";
        Response.Redirect("Input_Edit.aspx?ID=" + strID + "&ModuleID=" + Request["ModuleID"] + "&page=" + page);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "ddlOrg"] = null;
        Session[Request["ModuleID"] + "Class1"] = null;
        Session[Request["ModuleID"] + "txtSearch"] = null;

        Response.Redirect(Request.Url.ToString().Replace("page", "page1"));
    }
    protected void gvList_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (Convert.ToString(ViewState["sort"]) == "asc")
        {
            e.SortDirection = SortDirection.Descending;
        }
        else
        {
            e.SortDirection = SortDirection.Ascending;
        }

        if (e.SortDirection == SortDirection.Ascending)
        {
            strOrderBy = " order by " + e.SortExpression + " asc";
            ViewState["sort"] = "asc";
        }
        else
        {
            strOrderBy = " order by " + e.SortExpression + " desc";
            ViewState["sort"] = "desc";
        }
        foreach (DataControlField col in gvList.Columns)
        {
            col.HeaderText = col.HeaderText.Replace("▲", "").Replace("▼", "");
            if (col.SortExpression == e.SortExpression)
            {
                if (e.SortDirection == SortDirection.Ascending)
                {
                    col.HeaderText = col.HeaderText + "▲";
                }
                else
                {
                    col.HeaderText = col.HeaderText + "▼";
                }
            }
        }
        Show();
    }
}