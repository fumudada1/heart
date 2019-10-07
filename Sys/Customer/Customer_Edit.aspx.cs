using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Customer_Customer_Edit : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"

    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField) Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }

    #endregion
    EasyDataProvide _Customer = new EasyDataProvide("Customer");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show();
        }
    }
    private void Show()
    {
        DataRow row = _Customer.FillPlaceHolderControlsById(Request["id"]);
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
        _Customer.AddParameter("aliasName", aliasName.Text);
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
        _Customer.UpdateById(Request["id"]);
        My.WebForm.doJavaScript("alert('修改成功!');location.href='Customer_List.aspx?ModuleID=" + Request["ModuleID"] + "'");
    }
}