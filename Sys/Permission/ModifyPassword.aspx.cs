using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_A01Permission_ModifyPassword : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"
    protected void Page_Init(object sender, EventArgs e)
    {

        Literal litFunctionName = (Literal)Master.FindControl("litFunctionName");
        litFunctionName.Text = "修改密碼";
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        EasyDataProvide Member = new EasyDataProvide("Member");
        string password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
        string[] strUserData = ((FormsIdentity)(Page.User.Identity)).Ticket.UserData.Split(new Char[] { ';' });
        Member.AddParameter("password",password);
        Member.AddParameter("account",strUserData[4]);
        Member.Update("account=@account");
        My.WebForm.doJavaScript("alert('已經修改成功，下次登入請用新密碼登入')");
    }
}