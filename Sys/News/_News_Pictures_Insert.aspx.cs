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
        //�B�z�W�ǹϤ�
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
            ModulePictures.AddParameter("picUrl", fileName);
            //�����Y��

            My.WebForm.GenerateThumbnailImage(fileName, fuPic.PostedFile.InputStream, Server.MapPath("~/UploadFiles/Images/"), "S", 142, 89);

        }
        else
        {
            My.WebForm.doJavaScript("alert('�S���W���ɮ�');");
            return;
        }

        ModulePictures.AddParameter("publishID", Request["publishID"].ToString());

        ModulePictures.Insert();
        string Publish = "_News_Pictures.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
}