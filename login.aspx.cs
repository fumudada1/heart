using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Culture_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        TIN.EasyDataProvide Customer = new EasyDataProvide("Customer");
        Customer.AddParameter("username", account.Text);
        Customer.AddParameter("password", Password.Text);
        DataRow row = Customer.GetSingleRow("username=@username and password=@password");
        if (row == null)
        {
            lblErrer.Visible = true;
            My.WebForm.doJavaScript("alert('登入失敗！')");
            return;
        }
        else
        {
            string UserData = row["aliasName"].ToString();
            SetAuthenTicket(UserData, account.Text);
            Response.Redirect("member_atmbuy.aspx");
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
}