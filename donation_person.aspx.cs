using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class donation_person : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("index.aspx");

            }
            else
            {
			 string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                if (strUserData.Length > 20)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.Url.ToString());
                }
				
                Show();
            }

        }
    }

    private void Show()
    {

        int totaleItems = dl.GetInputDataListCount("True",User.Identity.Name,"","");
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "donation_person.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetInputDataList("True", User.Identity.Name,"","","", PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

    }
}