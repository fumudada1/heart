using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class member_person : System.Web.UI.Page
{
    EasyDataProvide _Customer = new EasyDataProvide("Customer");
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

        //DataRow row = _Customer.FillPlaceHolderControlsById(Request["id"]);
        _Customer.AddParameter("id", User.Identity.Name);
        DataRow row = _Customer.FillContentPlaceHolderControls("id=@id");
        if (row == null) return;
        hidzip.Value = row["zip"].ToString();
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        //更新帳號資料
        if (!string.IsNullOrEmpty(password.Text))
        {
            _Customer.AddParameter("password", password.Text);
        }
        _Customer.AddParameter("name", name.Text);
        _Customer.AddParameter("gender", gender.SelectedValue);
        _Customer.AddParameter("emailAddress", emailAddress.Text);
        _Customer.AddParameter("birthday", birthday.Text);
        _Customer.AddParameter("areaCode", areaCode.Value);
        _Customer.AddParameter("numberCode", numberCode.Value);
        _Customer.AddParameter("cellphone", cellphone.Text);
        _Customer.AddParameter("city", Request["city"]);
        _Customer.AddParameter("division", Request["division"]);
        _Customer.AddParameter("zip", Request["zip"]);
        _Customer.AddParameter("address", address.Value);
        _Customer.AddParameter("username", username.Text);
        _Customer.Update("username=@username");
        My.WebForm.doJavaScript("alert('修改成功!');location.href='index.aspx'");
    }
}