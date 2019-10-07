using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Output_Output_list : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 20;

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
            if (Session[Request["ModuleID"] + "txtSearch"] != null)
            {

                txtSearch.Text = Session[Request["ModuleID"] + "txtSearch"].ToString();
                //Session["txtSearch"] = null;
            }

            Show();
        }
    }


    private void Show()
    {

        int totaleItems = dl.GetOutputDateListCount(txtSearch.Text);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Output_list.aspx?ModuleID=" + Request["ModuleID"];
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetOutputDateList("", PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
        lnkAddAdmin.NavigateUrl = "Output_Insert.aspx?ModuleID=" + Request["ModuleID"];
        DataRow row = dl.GetInOutcoco();
        if (row == null) return;
        lblInput.Text = Convert.ToDouble(row["inputTotal"]) .ToString("C0");
        lblOutput.Text = Convert.ToDouble(row["outputTotal"]).ToString("C0");
        lblTotal.Text = Convert.ToDouble(row["subTotal"]).ToString("C0");


    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
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
        EasyDataProvide OutputDate = new EasyDataProvide("OutputDate");
        OutputDate.DeleteById(strID);
        Show();
    }
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        string page = Request["page"] ?? "1";
        Response.Redirect("Output_Edit.aspx?ID=" + strID + "&ModuleID=" + Request["ModuleID"] + "&page=" + page);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "ddlOrg"] = null;
        Session[Request["ModuleID"] + "Class1"] = null;
        Session[Request["ModuleID"] + "txtSearch"] = null;

        Response.Redirect(Request.Url.ToString().Replace("page", "page1"));
    }
}