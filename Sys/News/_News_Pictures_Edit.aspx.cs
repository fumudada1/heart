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
        if (ddlPic.SelectedValue == "�W�ǹϤ�")
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
        //�B�z�W�ǹϤ�
        if (ddlPic.SelectedValue == "�W�ǹϤ�")
        {
            if (fuPic.HasFile)
            {
                if (fuPic.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    My.WebForm.doJavaScript("alert('�ɮ׫��A���~!');");
                    return;
                }

                //���o���ɦW
                string Extension = fuPic.FileName.Split('.')[fuPic.FileName.Split('.').Length - 1];
                //�s�ɮצW��
                string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                fuPic.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Images/{0}", fileName)));
                _ModulePictures.AddParameter("picUrl", fileName);
                //�����Y��
          
                My.WebForm.GenerateThumbnailImage(fileName, fuPic.PostedFile.InputStream, Server.MapPath("~/UploadFiles/Images/"), "S", 142, 89);

            }
            else
            {
                My.WebForm.doJavaScript("alert('�S���W���ɮ�');");
                return;
            }
        }
        _ModulePictures.UpdateById(Request["ID"]);
        string Publish = "_News_Pictures.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
}