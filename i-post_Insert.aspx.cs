using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class i_post_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["GUID"] = Guid.NewGuid().ToString();
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
        if (string.IsNullOrEmpty(article.Text))
        {
            My.WebForm.doJavaScript("alert('詳細說明不可以空白.');");
            return;
        }
        DateTime d = DateTime.Now;

        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.SetPlaceHolderFormQuest();

        ModulePublish.AddParameter("id", ViewState["GUID"].ToString());
        ModulePublish.AddParameter("moduleID", "N02");
        ModulePublish.AddParameter("startDate", d.ToString());
        ModulePublish.AddParameter("endDate", "2800/1/1");
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
        ModulePublish.AddParameter("poster", strUserData);


        ModulePublish.Insert();

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", ViewState["GUID"].ToString());
        ModuleContents.AddParameter("article", article.Text);
        ModuleContents.Insert();



        EasyDataProvide ModuleFiles = new EasyDataProvide("ModuleFiles");
        //取得副檔名
        if (fileUrl.HasFile)
        {
            string Extension = fileUrl.FileName.Split('.')[fileUrl.FileName.Split('.').Length - 1];
            //新檔案名稱
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fileUrl.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Files/{0}", fileName)));
            ModuleFiles.AddParameter("fileUrl", fileName);
            ModuleFiles.AddParameter("fileName", "點我下載");


            ModuleFiles.AddParameter("publishID", ViewState["GUID"].ToString());
            //處理上傳檔案
            if (ddlFile.SelectedValue == "檔案連結")
            {
                ModuleFiles.AddParameter("fileUrl", fileUrlPath.Text);
            }

            ModuleFiles.Insert();
        }
        else if (fileUrlPath.Text != "")
        {
            ModuleFiles.AddParameter("fileName", "點我下載");


            ModuleFiles.AddParameter("publishID", ViewState["GUID"].ToString());
            //處理上傳檔案
            if (ddlFile.SelectedValue == "檔案連結")
            {
                ModuleFiles.AddParameter("fileUrl", fileUrlPath.Text);
            }

            ModuleFiles.Insert();
        }
        if (chkAlert.Checked)
        {
            EasyDataProvide Customer = new EasyDataProvide("Customer");
            DataTable dtCustomer = Customer.GetData("emailAddress IS NOT NULL AND emailAddress<>''");

            string subject = "【雲施團分享】" + title.Text;

            string mailBody = article.Text.Replace(@"/UploadFiles/", ConfigurationManager.AppSettings["ServerHost"] + @"/UploadFiles/");

            mailBody += "<br />發表人：" + strUserData + "|發表日期：" + d.ToShortDateString();

            mailBody += "<br /><br />文章出處：<a href='" + ConfigurationManager.AppSettings["ServerHost"] + "MemberNews_Detail.aspx?id=" + ViewState["GUID"].ToString() + "'>" + ConfigurationManager.AppSettings["ServerHost"] + "MemberNews_Detail.aspx?id=" + ViewState["GUID"].ToString() + "</a>";
            foreach (DataRow row in dtCustomer.Rows)
            {
                My.WebForm.SystemSendMailCC("Myer@mail.lts.tw", row["emailAddress"].ToString(), subject, mailBody);
            }

        }



        Response.Redirect("index.aspx");
    }

    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFile.SelectedValue == "檔案上傳")
        {
            fileUrl.Visible = true;
            fileUrlPath.Visible = false;
        }
        else
        {
            fileUrl.Visible = false;
            fileUrlPath.Visible = true;
        }
    }
}