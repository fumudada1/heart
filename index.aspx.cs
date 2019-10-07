using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Culture_index : System.Web.UI.Page
{
    DataLayer _dl = new DataLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            divAfter.Visible = false;
            divBefor.Visible = true;
        }
        else
        {
            string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            if (strUserData.Length > 20)
            {
                FormsAuthentication.SignOut();
                Response.Redirect(Request.Url.ToString());
            }
            userName.Text = strUserData;
            divAfter.Visible = true;
            divBefor.Visible = false;

        }
        if (!Page.IsPostBack)
        {
            ShowNews();
            ShowMemberNews();
        }
    }

    private void ShowNews()
    {
        DataTable dt = _dl.GetPublishList("N01", "", "", "","", DataLayer.SortMethed.OrderByInitDate, true, 5, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        repNews.DataSource = dt;
        repNews.DataBind();
    }

    private void ShowMemberNews()
    {
        DataTable dt = _dl.GetPublishList("N02", "", "", "","", DataLayer.SortMethed.OrderByInitDate, true, 5, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        repMemberNews.DataSource = dt;
        repMemberNews.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TIN.EasyDataProvide Customer = new EasyDataProvide("Customer");
        Customer.AddParameter("username", account.Text);
        Customer.AddParameter("password", password.Text);
        DataRow row = Customer.GetSingleRow("username=@username and password=@password");
        if (row == null)
        {
            My.WebForm.doJavaScript("alert('登入失敗！')");
            return;
        }
        else
        {
            string UserData = row["aliasName"].ToString();
            SetAuthenTicket(UserData, row["id"].ToString());
            Response.Redirect("index.aspx");
        }

    }

    //驗證函數
    void SetAuthenTicket(string userData, string userId)
    {
        //宣告一個驗證票
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
        //加密驗證票
        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
        //建立Cookie
        HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        //將Cookie寫入回應
        Response.Cookies.Add(authenticationcookie);

    }
    protected void btn_logout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("index.aspx");
    }

}