using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Edit : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();

    #region "將目前功能資料送到Master Page裡"
    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ModuleID = Request["ModuleID"];
            ShowOrg();
            ShowClass1();
            show();
            ddlClass1.Enabled = false;


        }
    }

    private void show()
    {
        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        DataRow row = ModulePublish.FillPlaceHolderControlsById(Request["ID"]);
        ViewState["GUID"] = Request["ID"];
        ddlClass1.SelectedValue = row["classID"].ToString();
        ddlOrg.SelectedValue = row["OrgID"].ToString();
        if (endDate.Text == "2800/1/1")
        {
            endDate.Text = "";
        }
        if (string.IsNullOrEmpty(row["picUrl"].ToString()))
        {
            picUrlLink.Visible = false;
        }
        else
        {
            picUrlLink.NavigateUrl = row["picUrl"].ToString().IndexOf("http") == -1 ? "~/UploadFiles/Images/" + row["picUrl"].ToString() : row["picUrl"].ToString();
        }


        if (string.IsNullOrEmpty(row["fileUrl"].ToString()))
        {
            fileUrlLink.Visible = false;
        }
        else
        {
            fileUrlLink.NavigateUrl = row["fileUrl"].ToString().IndexOf("http") == -1
                                          ? "~/UploadFiles/Files/" + row["fileUrl"].ToString()
                                          : row["fileUrl"].ToString();
        }

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        DataRow rowArticle = ModuleContents.GetSingleRow("publishID=@publishID and type is null");
        if (rowArticle != null)
        {
            article.Text = rowArticle["article"].ToString();
            ViewState["articleID"] = rowArticle["id"].ToString();
        }


        //if (!DataLayer.IsInRole("admins", User.Identity.Name))
        //{
        //    if (row["beSelect"].ToString() != "0") //不是自己發佈的
        //    {
        //        OrgControl.checkBoxList.Enabled = false;
        //        InsertButton.Visible = false;
        //    }
        //    else
        //    {
        //        string[] strUserData = ((FormsIdentity)(User.Identity)).Ticket.UserData.Split(new Char[] { ';' });
        //        for (int i = OrgControl.checkBoxList.Items.Count - 1; i >= 0; i--)
        //        {
        //            ListItem item = OrgControl.checkBoxList.Items[i];
        //            if (item.Value.IndexOf(strUserData[5]) == -1)
        //            {
        //                OrgControl.checkBoxList.Items.Remove(item);

        //            }
        //        }

        //    }

        //}
    }

    private void ShowClass1()
    {
        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        DataTable dtClass = ModuleClass.GetData(string.Format("moduleID='{0}'", Request["ModuleID"]));
        ddlClass1.DataSource = dtClass;
        ddlClass1.DataBind();
    }

    private void ShowOrg()
    {
        EasyDataProvide UnitName = new EasyDataProvide("UnitName");
        DataTable dt = UnitName.GetAllData();
        ddlOrg.DataSource = dt;
        ddlOrg.DataBind();


    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(article.Text))
        {
            My.WebForm.doJavaScript("alert('詳細說明不可以空白.');");
            return;
        }
        //if (shortDescription.Text.Length >=500)
        //{
        //    My.WebForm.doJavaScript("alert('簡單說明不可以超過500個字.');");
        //    return;
        //}

        Person person = new Person();

        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.SetPlaceHolderFormQuest();
        //處理上傳檔案
        if (ddlFile.SelectedValue == "檔案上傳" && fuFile.HasFile)
        {
            //取得副檔名
            string Extension = fuFile.FileName.Split('.')[fuFile.FileName.Split('.').Length - 1];
            //新檔案名稱
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fuFile.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Files/{0}", fileName)));
            ModulePublish.AddParameter("fileUrl", fileName);

        }

        //處理上傳圖片

        if (fuPic.HasFile)
        {
            if (fuPic.PostedFile.ContentType.IndexOf("image") == -1)
            {
                My.WebForm.doJavaScript("alert('檔案型態錯誤!');");
                return;
            }

            //取得副檔名
            string Extension = fuPic.FileName.Split('.')[fuPic.FileName.Split('.').Length - 1];
            //新檔案名稱
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fuPic.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Images/{0}", fileName)));
            My.WebForm.GenerateThumbnailImage(fileName, fuPic.PostedFile.InputStream, Server.MapPath("~/UploadFiles/Images/"), "S", 127, 127);
            ModulePublish.AddParameter("picUrl", fileName);

        }

        ModulePublish.AddParameter("classID", ddlClass1.SelectedValue);
        ModulePublish.AddParameter("OrgID", ddlOrg.SelectedValue);
        ModulePublish.AddParameter("OrgNames", ddlOrg.SelectedItem.Text);
        ModulePublish.AddParameter("updater", person.name);
        ModulePublish.AddParameter("updaterUnit", person.organization);
        ModulePublish.AddParameter("lastupdated", DateTime.Now.ToString());
        //不填結束日期時，設定一個800年後的日期
        if (string.IsNullOrEmpty(endDate.Text))
        {
            ModulePublish.AddParameter("endDate", "2800/1/1");
        }
        ModulePublish.UpdateById(Request["ID"]);

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("article", article.Text);
        ModuleContents.UpdateById(ViewState["articleID"].ToString());

       

        Response.Redirect(String.Format("News_List.aspx?ModuleID={0}&page={1}", Request["ModuleID"], Request["page"]));
    }

    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFile.SelectedValue == "檔案上傳")
        {
            fuFile.Visible = true;
            fileUrl.Visible = false;
        }
        else
        {
            fuFile.Visible = false;
            fileUrl.Visible = true;
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EasyDataProvide Customer = new EasyDataProvide("Customer");
        DataTable dtCustomer = Customer.GetData("emailAddress IS NOT NULL AND emailAddress<>''");

        string subject = "【雲施團分享】" + title.Text;

        string mailBody = article.Text.Replace(@"/UploadFiles/", ConfigurationManager.AppSettings["ServerHost"] + @"/UploadFiles/");

        mailBody += "<br />發表人：團長|發表日期：" + DateTime.Now.ToShortDateString();

        mailBody += "<br /><br />文章網址：<a href='" + ConfigurationManager.AppSettings["ServerHost"] + "News_Detail.aspx?id=" + ViewState["GUID"].ToString() + "'>" + ConfigurationManager.AppSettings["ServerHost"] + "News_Detail.aspx?id=" + ViewState["GUID"].ToString() + "</a>";

        //My.WebForm.SystemSendMailCC("Myer@mail.lts.tw", "little_yunyun@msn.com", subject, mailBody);
        foreach (DataRow row in dtCustomer.Rows)
        {
            My.WebForm.SystemSendMailCC("MyerSystem@myerstone.com.tw", row["emailAddress"].ToString(), subject, mailBody);
        }
        Response.Redirect(String.Format("News_List.aspx?ModuleID={0}&page={1}", Request["ModuleID"], Request["page"]));
    }
}