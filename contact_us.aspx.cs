using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Culture_contact_us : System.Web.UI.Page
{
    private Random random = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
			 string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                if (strUserData.Length > 20)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.Url.ToString());
                }
				
                string username = User.Identity.Name;

                EasyDataProvide Customer = new EasyDataProvide("Customer");
                Customer.AddParameter("username", username);
                DataRow rowCustomer = Customer.GetSingleRow("username=@username");
                if (rowCustomer == null)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("index.aspx");
                }
                allName.Text = rowCustomer["name"].ToString();
                gender.SelectedValue=rowCustomer["gender"].ToString();
                emailAddress.Text=rowCustomer["emailAddress"].ToString();
                phoneNumber.Text = rowCustomer["areaCode"].ToString() + "-" + rowCustomer["numberCode"].ToString();

            }


            //驗證圖片產生
            string captchaImageText = GenerateRandomCode();
            this.Session["Captcha"] = captchaImageText;
            ViewState["Captcha"] = captchaImageText;
            imgMVcode.Src = "../Ashx/JpegImage.ashx"; ;
        }
    }
    private string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(allName.Text))
        {
            My.WebForm.doJavaScript("alert('您的姓名尚未填寫!');");
            return;
        }
        if (string.IsNullOrEmpty(emailAddress.Text))
        {
            My.WebForm.doJavaScript("alert('您的電子郵件尚未填寫!');");
            return;
        }
        if (!My.WebForm.IsValidEmail(emailAddress.Text))
        {
            My.WebForm.doJavaScript("alert('您的電子郵件格式有誤!');");
            return;
        }
        if (string.IsNullOrEmpty(phoneNumber.Text))
        {
            My.WebForm.doJavaScript("alert('您的聯絡電話尚未填寫!');");
            return;
        }
        if (string.IsNullOrEmpty(article.Text))
        {
            My.WebForm.doJavaScript("alert('問題或建議必填!');");
            return;
        }
        if (txtVCode.Text != ViewState["Captcha"].ToString())
        {
            My.WebForm.doJavaScript("alert('驗證碼輸入錯誤!');");
            return;
        }

        ViewState["GUID"] = Guid.NewGuid().ToString();
        EasyDataProvide Contact = new EasyDataProvide("Contact");
        Contact.SetPlaceHolderFormQuest();

        Contact.AddParameter("id", ViewState["GUID"].ToString());
        Contact.AddParameter("questionClass", ddlQuestionClass.SelectedValue);
        Contact.Insert();

        My.WebForm.doJavaScript("alert('問題已送出，感謝您的意見！');location.href='index.aspx'");
    }
}