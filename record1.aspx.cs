using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class record1 : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show();

        }
    }

    private void Show()
    {

        int totaleItems = dl.GetOutputDateListCount("");
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Output_list.aspx?ModuleID=" + Request["ModuleID"];
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetOutputDateList("", PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        DataRow row = dl.GetInOutcoco();
        if (row == null) return;
        lblInput.Text = Convert.ToDouble(row["inputTotal"]).ToString("C0");
        lblOutput.Text = Convert.ToDouble(row["outputTotal"]).ToString("C0");
        lblTotal.Text = Convert.ToDouble(row["subTotal"]).ToString("C0");

    }
}