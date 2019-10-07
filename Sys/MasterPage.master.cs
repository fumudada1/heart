using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Security;
using System.Xml.XPath;
using System.Xml.Xsl;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //驗證身份
        if (Page.User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/Sys/Login.aspx");
        }
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
        if (strUserData.Length < 20)
        {
            Response.Redirect("~/Sys/Login.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Person person=new Person();
      
            //  是否有權限
            if (FunctionNumber.Value == "")
            {
                content_title.Visible = false;
            }



            lblUserName.Text =person.organization + "/" + person.name;
            getMenu(person.permission);
        }

    }

    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Sys/Login.aspx");
    }

    void getMenu(string permission)
    {
        StringBuilder stringBuilder = new StringBuilder();
        StringWriter sw = new StringWriter(stringBuilder);
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("~/Sys/Menu.xml"));
        XmlNode xmlNode = doc.SelectSingleNode("//Modules[@value='" + FunctionNumber.Value + "']");
        if (xmlNode != null) litFunctionName.Text = xmlNode.Attributes["Title"].Value;
        XsltArgumentList args = new XsltArgumentList();
        args.AddParam("permission", "", permission);
        args.AddParam("moduleID", "", FunctionNumber.Value);
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(Server.MapPath("~/Sys/menu.xslt"));
        xslt.Transform(doc, args, sw);
        litMenu.Text = stringBuilder.ToString().Replace("~/Sys/", Page.ResolveUrl("~/Sys/"));

    }

}
