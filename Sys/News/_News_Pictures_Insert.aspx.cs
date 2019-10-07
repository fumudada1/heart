using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Pictures_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        EasyDataProvide ModulePictures = new EasyDataProvide("ModulePictures");
        ModulePictures.SetPageFormQuest();
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
            ModulePictures.AddParameter("picUrl", fileName);
            //產生縮圖

            My.WebForm.GenerateThumbnailImage(fileName, fuPic.PostedFile.InputStream, Server.MapPath("~/UploadFiles/Images/"), "S", 142, 89);

        }
        else
        {
            My.WebForm.doJavaScript("alert('沒有上傳檔案');");
            return;
        }

        ModulePictures.AddParameter("publishID", Request["publishID"].ToString());

        ModulePictures.Insert();
        string Publish = "_News_Pictures.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
}