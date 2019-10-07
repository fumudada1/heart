using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mailTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       SystemSendMailCC("MyerSystem@myerstone.com.tw", "topidea.justin@gmail.com", "我要吃雞排", "我要吃雞排我要吃雞排我要吃雞排我要吃雞排");
    }

    void SystemSendMailCC(string fromAddress, string toAddress, string Subject, string MailBody)
    {
        //MailMessage mailMessage = new MailMessage("MyerSystem@myerstone.com.tw", "system@mail.lts.tw");
        //mailMessage.Bcc.Add(toAddress);


        //mailMessage.Subject = Subject;
        //mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
        //mailMessage.IsBodyHtml = true;
        //mailMessage.Body = MailBody;

        //// SMTP Server
        //System.Net.Mail.SmtpClient client = new SmtpClient();
        //client.EnableSsl = false;
        //client.Send(mailMessage);
        //mailMessage.Dispose();
        //try
        //{

        //    client.Send(mailMessage);
        //    mailMessage.Dispose();
        //}
        //catch
        //{
        //    return;
        //}
        //client = null;




        MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
        //mailMessage.Bcc.Add(toAddress);


        mailMessage.Subject = Subject;
        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = MailBody;

        // SMTP Server

        try
        {
            System.Net.Mail.SmtpClient client = new SmtpClient("127.0.0.1");
            client.EnableSsl = false;
            client.Send(mailMessage);
            mailMessage.Dispose();
        }
        catch (Exception e)
        {

            return;
        }
    }

}