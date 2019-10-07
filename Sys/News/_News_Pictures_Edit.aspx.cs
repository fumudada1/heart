using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Pictures_Edit : System.Web.UI.Page
{
    private EasyDataProvide _ModulePictures = new EasyDataProvide("ModulePictures");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }
    }

    private void show()
    {
        _ModulePictures.FillPageControlsById(Request["ID"].ToString());

    }
    protected void ddlPic_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPic.SelectedValue == "上傳圖片")
        {
            fuPic.Visible = true;
            picUrl.Visible = false;
        }
        else
        {
            fuPic.Visible = false;
            picUrl.Visible = true;
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        _ModulePictures.SetPageFormQuest();
        //處理上傳圖片
        if (ddlPic.SelectedValue == "上傳圖片")
        {
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
                _ModulePictures.AddParameter("picUrl", fileName);
                //產生縮圖
          
                My.WebForm.GenerateThumbnailImage(fileName, fuPic.PostedFile.InputStream, Server.MapPath("~/UploadFiles/Images/"), "S", 142, 89);

            }
            else
            {
                My.WebForm.doJavaScript("alert('沒有上傳檔案');");
                return;
            }
        }
        _ModulePictures.UpdateById(Request["ID"]);
        string Publish = "_News_Pictures.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
}