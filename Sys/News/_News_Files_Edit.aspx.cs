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
        //�ŧi�ɮפW�ǳ]�w
        FileUploadSetup fus = new FileUploadSetup();
        fus.name = "fileUrl";
        fus.fileType = FileUploadSetup.UpfileType.File;
        fus.allowNoFile = true;
        _ModuleFiles.FileUploadSetups.Add(fus);

        try //����ۭq���~
        {
            _ModuleFiles.SetPageFormQuest();
        }
        catch (Exception ex1)
        {
            lblError.Text = ex1.Message;
            return;
        }

        //�B�z�W���ɮ�
        if (ddlFile.SelectedValue == "�ɮ׳s��")
        {
            _ModuleFiles.AddParameter("fileUrl", fileUrlPath.Text);
        }

        _ModuleFiles.UpdateById(Request["ID"].ToString());

        string Publish = "_News_Files.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFile.SelectedValue == "�ɮפW��")
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