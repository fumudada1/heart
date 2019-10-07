<%@ Page ValidateRequest="false"  Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="i-post_Insert.aspx.cs" Inherits="i_post_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker-zh-TW.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/webEditor/ckeditor1/ckeditor.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.core.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.datepicker.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.theme.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $(".datepicker input").datepicker();

        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <h1>團員專區</h1>
 <div class="member_btn">
<a class="member_btn_1" href="member_person.aspx" title="修改團員資料"></a>
<a class="member_btn_2"  href="donation_person.aspx" title="善款明細記錄"></a>
<a class="member_btn_4_1"  href="i-post.aspx" title="發表團員分享"></a>
<a class="member_btn_3"  href="i-donation.aspx" title="捐贈登錄"></a>

</div>
 <table width="100%" class="from_table_2">
<tr>

    <th scope="col">標　　題</th>
    <td ><asp:TextBox ID="title" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'標題必填'}}}"></asp:TextBox></td>
  </tr>
 <tr>

    <th scope="col">內　　容</th>
    <td >
     <asp:TextBox ID="article" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
    </td>
  </tr>
  <tr>

    <th scope="col">附件下載</th>
    <td >
        <asp:DropDownList
                ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                <asp:ListItem>檔案上傳</asp:ListItem>
                <asp:ListItem>檔案連結</asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="fileUrl" runat="server" />
            <asp:TextBox ID="fileUrlPath" runat="server" Width="250px" Visible="False" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>

    </td>
  </tr>
                     <tr style="display: inherit">
            <th>
                E-mail 通知團員</th>
            <td >
                <asp:CheckBox ID="chkAlert" runat="server" Checked="True" />
            </td>
        </tr>
</table>
<div class="bottom_btn">
             <asp:Button ID="InsertButton" runat="server" Text="發表" CssClass="btn_small" OnClick="InsertButton_Click">
        </asp:Button>
           
             <input class="btn_small" type="button" value="取消"  onclick="javascript: history.back();"  />
        </div>
</asp:Content>

