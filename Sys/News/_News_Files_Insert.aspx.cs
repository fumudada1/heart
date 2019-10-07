using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Files_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        EasyDataProvide ModuleFiles = new EasyDataProvide("ModuleFiles");
        //�ŧi�ɮפW�ǳ]�w
        FileUploadSetup fus = new FileUploadSetup();
        fus.name = "fileUrl";
        fus.fileType = FileUploadSetup.UpfileType.File;
        fus.allowNoFile = false;

        ModuleFiles.FileUploadSetups.Add(fus);

        try //����ۭq���~
        {
            ModuleFiles.SetPageFormQuest();
        }
        catch (Exception ex1)
        {
            lblError.Text = ex1.Message;
            return;
        }



        ModuleFiles.AddParameter("publishID", Request["publishID"].ToString());
        //�B�z�W���ɮ�
        if (ddlFile.SelectedValue == "�ɮ׳s��")
        {
            ModuleFiles.AddParameter("fileUrl", fileUrlPath.Text);
        }

        ModuleFiles.Insert();

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