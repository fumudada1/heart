using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class manage_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnButton_Click(object sender, ImageClickEventArgs e)
    {
        //檢查是不是最新的警員(Member 有沒有資料)
        DataLayer dataLayer = new DataLayer();
        DataRow row = dataLayer.Login(Username.Text, Password.Text);
        if (row != null)
        {
            //TODO:定義UserData,可以存放使用者資訊到Cookie,記住!!UserData因為是放在Cookie,所以IE和Netscape所支援的最大容量為4096bytes
            //    //UserData為一個字串用";"分開每個功能作用
            //    //目前的定義:所屬角色ID
            SPerson person=new SPerson();
            person.account = Username.Text;
            person.name = row["name"].ToString();
            person.Permission = dataLayer.GetPermissionStringByID(row["id"].ToString());
            person.Organization = row["Organization"].ToString();
            person.email = row["email"].ToString();
            
            string userData = JsonConvert.SerializeObject(person);
            SetAuthenTicket(userData, Username.Text);
            Response.Redirect("~/sys/Permission/Ready.aspx");
            
        }
        else
        {
            lblErrer.Text = "登入失敗!!";

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