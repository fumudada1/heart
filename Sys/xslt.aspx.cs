using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Xml.Xsl;

public partial class manage_xslt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder stringBuilder=new StringBuilder();
        StringWriter sw=new StringWriter(stringBuilder);
        XPathDocument doc = new XPathDocument(Server.MapPath("Menu.xml"));
        XsltArgumentList args=new XsltArgumentList();
        args.AddParam("permission", "", "A01,C,B02,B03,H01");
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(Server.MapPath("menu.xslt"));
        xslt.Transform(doc,args,sw);
        TextBox1.Text = stringBuilder.ToString();

    }
}