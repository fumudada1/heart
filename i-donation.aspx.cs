using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class i_donation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("index.aspx");

            }else{
				 string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                 if (strUserData.Length > 20)
                 {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.Url.ToString());
                 }
			}
           

        }
    }

  
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;

        EasyDataProvide InputData = new EasyDataProvide("InputData");
        InputData.SetPlaceHolderFormQuest();
        InputData.AddParameter("customerID", User.Identity.Name);
        InputData.AddParameter("aliasName", strUserData);
        InputData.Insert();
        My.WebForm.doJavaScript("alert('已送出！管理者審核中！');location='index.aspx'");
    }
}