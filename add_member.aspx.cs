using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class add_member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        //檢查帳號是否重複
        EasyDataProvide Customer = new EasyDataProvide("Customer");
        Customer.AddParameter("username", username.Text);
        DataRow rowCheck = Customer.GetSingleRow("username=@username");
        if (rowCheck != null)
        {
            My.WebForm.doJavaScript("alert('帳號已經存在')");
            return;
        }

        //驗證手機號碼格式
        

        //新增會員
        Customer.SetPlaceHolderFormQuest();
        Customer.AddParameter("password", password.Text);
        Customer.AddParameter("city", Request["city"]);
        Customer.AddParameter("division", Request["division"]);
        Customer.AddParameter("zip", Request["zip"]);

        Customer.Insert();
        My.WebForm.doJavaScript("alert('加入成功!');location.href='index.aspx'");
    }
}