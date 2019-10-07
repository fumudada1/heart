using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class forget : System.Web.UI.Page
{
    private Random random = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SureButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide Customer = new EasyDataProvide("Customer");
        Customer.AddParameter("username", username.Text);
        Customer.AddParameter("emailAddress", emailAddress.Text);
        DataRow row = Customer.GetSingleRow("username=@username and emailAddress=@emailAddress");
        if (row == null)
        {
            lblMessage.Text = "填入資料與資料庫不符，請恰尋管理者，謝謝";
            return;
        }

        //取得新密碼
        string newPassword = GenerateRandomCode();
        Customer.RemoveParameter("emailAddress");
        Customer.AddParameter("password", newPassword);
        Customer.Update("username=@username");

        //送到信箱
        
        
        EasyDataProvide EmailTemplats = new EasyDataProvide("EmailTemplats");
        EmailTemplats.AddParameter("number", "ForgetPassword");
        DataRow rowEmail = EmailTemplats.GetSingleRow("number=@number");
        if (rowEmail != null)
        {
            string subject = rowEmail["subject"].ToString();
            string EmailTemp = rowEmail["article"].ToString();
            string mailBody = "";
            mailBody = EmailTemp;
            mailBody = mailBody.Replace("{account}", username.Text).Replace("{password}", newPassword);
            My.WebForm.SystemSendMailCC("Myer@mail.lts.tw", emailAddress.Text, subject, mailBody);
        }
        

        My.WebForm.doJavaScript("alert('密碼已經寄到您註冊的信箱!')");
    }
    private string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 4; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }
}