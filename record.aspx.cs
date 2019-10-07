using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class record : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 20;
    string strOrderBy = "ORDER BY payDate DESC";   //排序

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (DataControlField col in GridView1.Columns)
            {
                col.HeaderText = col.HeaderText.Replace("▲", "").Replace("▼", "");
                if (col.SortExpression == "payDate")
                {
                    col.HeaderText = col.HeaderText + "▼";

                }
            }
            Show();

        }
    }

    private void Show()
    {

        int totaleItems = dl.GetInputDataListCount("True", "","","");
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "record.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetInputDataList("True", "", "", "", strOrderBy, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        GridView1.DataSource = dt;
        GridView1.DataBind();
        DataRow row = dl.GetInOutcoco();
        if (row == null) return;
        lblInput.Text = Convert.ToDouble(row["inputTotal"]).ToString("C0");
        lblOutput.Text = Convert.ToDouble(row["outputTotal"]).ToString("C0");
        lblTotal.Text = Convert.ToDouble(row["subTotal"]).ToString("C0");

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
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
        foreach (DataControlField col in GridView1.Columns)
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