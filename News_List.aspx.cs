using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News_List : System.Web.UI.Page
{
       private const int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["News" + "txtSearch"] != null)
            {
                txtSearch.Text = Session["News" + "txtSearch"].ToString();
            }
            Show();
        }
    }

    private void Show()
    {
        DataLayer dl = new DataLayer();
        int totaleItems = dl.GetPublishListCount("N01","","", txtSearch.Text,"",DataLayer.SortMethed.OrderByInitDate,true);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "News_List.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetPublishList("N01", "", "", txtSearch.Text,"", DataLayer.SortMethed.OrderByInitDate, true, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session["News" + "txtSearch"] = null;
        Response.Redirect(Request.Url.ToString().Replace("page","page1"));
    }
   

    protected void SureBtn_Click1(object sender, EventArgs e)
    {
        Session["News" + "txtSearch"] = txtSearch.Text;
        Response.Redirect(Request.Url.ToString().Replace("page", "page1"));
    }
}
