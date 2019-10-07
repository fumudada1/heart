using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Files_Edit : System.Web.UI.Page
{
    private EasyDataProvide _ModuleFiles = new EasyDataProvide("ModuleFiles");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }
    }

    private void show()
    {
        DataRow row = _ModuleFiles.FillPageControlsById(Request["ID"]);
        fileUrlPath.Text = row["fileUrl"].ToString();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //宣告檔案上傳設定
        FileUploadSetup fus = new FileUploadSetup();
        fus.name = "fileUrl";
        fus.fileType = FileUploadSetup.UpfileType.File;
        fus.allowNoFile = true;
        _ModuleFiles.FileUploadSetups.Add(fus);

        try //捕抓自訂錯誤
        {
            _ModuleFiles.SetPageFormQuest();
        }
        catch (Exception ex1)
        {
            lblError.Text = ex1.Message;
            return;
        }

        //處理上傳檔案
        if (ddlFile.SelectedValue == "檔案連結")
        {
            _ModuleFiles.AddParameter("fileUrl", fileUrlPath.Text);
        }

        _ModuleFiles.UpdateById(Request["ID"].ToString());

        string Publish = "_News_Files.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
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