using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_ModuleAuto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!System.IO.Directory.Exists(Server.MapPath(txtModuleName.Text)))
        {
            System.IO.Directory.CreateDirectory(Server.MapPath(txtModuleName.Text));
        }
        //列表
        string ListAspnet = "";
        string ListCS = "";
        if (ddlType.SelectedValue == "0") //自訂排序
        {
            ListAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_List_Sort.aspx"), System.Text.Encoding.Default);
            ListCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_List_Sort.aspx.cs"), System.Text.Encoding.Default);


        }
        else
        {
            ListAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_List.aspx"), System.Text.Encoding.Default);
            ListCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_List.aspx.cs"), System.Text.Encoding.Default);
        }
        ListAspnet = ListAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        ListAspnet = ListAspnet.Replace("_Sort", "");
        ListAspnet = ListAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");
        ListAspnet = ListAspnet.Replace("value=\"新增訊息\"", "value=\"新增" + txtCName.Text + "\"");

        ListCS = ListCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        ListCS = ListCS.Replace("_Sort", "");
        //新增
        string InsertAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_Insert.aspx"), System.Text.Encoding.Default);
        string InsertCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_Insert.aspx.cs"),
                                                     System.Text.Encoding.Default);
        InsertAspnet = InsertAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        InsertAspnet = InsertAspnet.Replace("Title=\"\"", "Title=\"新增" + txtCName.Text + "\"");

        InsertCS = InsertCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        //編輯
        string EditAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_Edit.aspx"), System.Text.Encoding.Default);
        string EditCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_Edit.aspx.cs"),
                                                     System.Text.Encoding.Default);
        EditAspnet = EditAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        EditAspnet = EditAspnet.Replace("Title=\"\"", "Title=\"編輯" + txtCName.Text + "\"");

        EditCS = EditCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);


        //類別
        string ClassAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_Class.aspx"), System.Text.Encoding.Default);
        string ClassCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_Class.aspx.cs"),
                                                     System.Text.Encoding.Default);
        ClassAspnet = ClassAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        ClassAspnet = ClassAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "-類別維護\"");

        ClassCS = ClassCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        //內文

        string ArticlesAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Articles.aspx"), System.Text.Encoding.Default);
        string ArticlesCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Articles.aspx.cs"),
                                                     System.Text.Encoding.Default);
        ArticlesAspnet = ArticlesAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        ArticlesAspnet = ArticlesAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "-內容編輯\"");

        ArticlesCS = ArticlesCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        //附加檔案
        string FilesAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Files.aspx"), System.Text.Encoding.Default);
        string FilesCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Files.aspx.cs"),
                                                     System.Text.Encoding.Default);
        FilesAspnet = FilesAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        FilesAspnet = FilesAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "-附加檔案\"");

        FilesCS = FilesCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);


        string Files_InsertAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Files_Insert.aspx"), System.Text.Encoding.Default);
        string Files_InsertCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Files_Insert.aspx.cs"),
                                                     System.Text.Encoding.Default);
        Files_InsertAspnet = Files_InsertAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        Files_InsertAspnet = Files_InsertAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");

        Files_InsertCS = Files_InsertCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        string Files_EditAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Files_Edit.aspx"), System.Text.Encoding.Default);
        string Files_EditCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Files_Edit.aspx.cs"),
                                                     System.Text.Encoding.Default);
        Files_EditAspnet = Files_EditAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        Files_EditAspnet = Files_EditAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");

        Files_EditCS = Files_EditCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);


        //附加圖片
        string PicturesAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Pictures.aspx"), System.Text.Encoding.Default);
        string PicturesCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Pictures.aspx.cs"),
                                                     System.Text.Encoding.Default);
        PicturesAspnet = PicturesAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        PicturesAspnet = PicturesAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "-附加圖片\"");

        PicturesCS = PicturesCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        string Pictures_InsertAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Pictures_Insert.aspx"), System.Text.Encoding.Default);
        string Pictures_InsertCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Pictures_Insert.aspx.cs"),
                                                     System.Text.Encoding.Default);
        Pictures_InsertAspnet = Pictures_InsertAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        Pictures_InsertAspnet = Pictures_InsertAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");

        Pictures_InsertCS = Pictures_InsertCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        string Pictures_EditAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Pictures_Edit.aspx"), System.Text.Encoding.Default);
        string Pictures_EditCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Pictures_Edit.aspx.cs"),
                                                     System.Text.Encoding.Default);
        Pictures_EditAspnet = Pictures_EditAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        Pictures_EditAspnet = Pictures_EditAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");

        Pictures_EditCS = Pictures_EditCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);


        //附加連結
        string LinksAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Links.aspx"), System.Text.Encoding.Default);
        string LinksCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Links.aspx.cs"),
                                                     System.Text.Encoding.Default);
        LinksAspnet = LinksAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        LinksAspnet = LinksAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "-附加連結\"");

        LinksCS = LinksCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        string Links_InsertAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Links_Insert.aspx"), System.Text.Encoding.Default);
        string Links_InsertCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Links_Insert.aspx.cs"),
                                                     System.Text.Encoding.Default);
        Links_InsertAspnet = Links_InsertAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        Links_InsertAspnet = Links_InsertAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");

        Links_InsertCS = Links_InsertCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);

        string Links_EditAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Links_Edit.aspx"), System.Text.Encoding.Default);
        string Links_EditCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/_demo_Links_Edit.aspx.cs"),
                                                     System.Text.Encoding.Default);
        Links_EditAspnet = Links_EditAspnet.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);
        Links_EditAspnet = Links_EditAspnet.Replace("Title=\"\"", "Title=\"" + txtCName.Text + "\"");

        Links_EditCS = Links_EditCS.Replace("ListDemo", txtModuleName.Text).Replace("demo", txtModuleName.Text);


        //存檔
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_List.aspx"), ListAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_List.aspx.cs"), ListCS, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_Insert.aspx"), InsertAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_Insert.aspx.cs"), InsertCS, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_Edit.aspx"),
                                    EditAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_Edit.aspx.cs"), EditCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_Class.aspx"), ClassAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/" + txtModuleName.Text + "_Class.aspx.cs"), ClassCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Articles.aspx"), ArticlesAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Articles.aspx.cs"), ArticlesCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Files.aspx"), FilesAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Files.aspx.cs"), FilesCS, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Files_Insert.aspx"), Files_InsertAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Files_Insert.aspx.cs"), Files_InsertCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Files_Edit.aspx"), Files_EditAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Files_Edit.aspx.cs"), Files_EditCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Pictures.aspx"), PicturesAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Pictures.aspx.cs"), PicturesCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Pictures_Insert.aspx"), Pictures_InsertAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Pictures_Insert.aspx.cs"), Pictures_InsertCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Pictures_Edit.aspx"), Pictures_EditAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Pictures_Edit.aspx.cs"), Pictures_EditCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Links.aspx"), LinksAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Links.aspx.cs"), LinksCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Links_Insert.aspx"), Links_InsertAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Links_Insert.aspx.cs"), Links_InsertCS, System.Text.Encoding.Default);

        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Links_Edit.aspx"), Links_EditAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath(txtModuleName.Text + "/_" + txtModuleName.Text + "_Links_Edit.aspx.cs"), Links_EditCS, System.Text.Encoding.Default);
        My.WebForm.doJavaScript("alert(\'建立成功\');");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      
        //列表
        string ListAspnet = "";
        string ListCS = "";
        if (ddlType.SelectedValue == "0") //自訂排序
        {
            ListAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_List.aspx"), System.Text.Encoding.Default);
            ListCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/demo_List.aspx.cs"), System.Text.Encoding.Default);


        }
        else
        {
            ListAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/fDemo_List.aspx"), System.Text.Encoding.Default);
            ListCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/fDemo_List.aspx.cs"), System.Text.Encoding.Default);
        }

        ListAspnet = ListAspnet.Replace("fDemo", txtModuleName.Text);
        ListAspnet = ListAspnet.Replace("N01", txtModuleID.Text);

        ListCS = ListCS.Replace("fDemo", txtModuleName.Text);
        ListCS = ListCS.Replace("N01", txtModuleID.Text);

        System.IO.File.WriteAllText(Server.MapPath("~/" + txtModuleName.Text + "_List.aspx"), ListAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath("~/" + txtModuleName.Text + "_List.aspx.cs"), ListCS, System.Text.Encoding.Default);
        
        //內頁
        ListAspnet = System.IO.File.ReadAllText(Server.MapPath("ListDemo/fDemo_Detail.aspx"), System.Text.Encoding.Default);
        ListCS = System.IO.File.ReadAllText(Server.MapPath("ListDemo/fDemo_Detail.aspx.cs"), System.Text.Encoding.Default);

        ListAspnet = ListAspnet.Replace("fDemo", txtModuleName.Text);
        ListAspnet = ListAspnet.Replace("N01", txtModuleID.Text);

        ListCS = ListCS.Replace("fDemo", txtModuleName.Text);
        ListCS = ListCS.Replace("N01", txtModuleID.Text);

        System.IO.File.WriteAllText(Server.MapPath("~/" + txtModuleName.Text + "_Detail.aspx"), ListAspnet, System.Text.Encoding.Default);
        System.IO.File.WriteAllText(Server.MapPath("~/" + txtModuleName.Text + "_Detail.aspx.cs"), ListCS, System.Text.Encoding.Default);

       
        My.WebForm.doJavaScript("alert(\'建立成功\');");
    }
}