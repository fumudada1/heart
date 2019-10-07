<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="i-post_Edit.aspx.cs" Inherits="i_post_Edit" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker-zh-TW.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.maxlength-min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/webEditor/ckeditor/ckeditor.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.core.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.datepicker.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.theme.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/maxlength.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $(".datepicker input").datepicker();
            $('.max textarea').maxlength({
                maxCharacters: 100, // Characters limit      

                notificationClass: "notification", // Will be added when maxlength is reached  
                showAlert: true, // True to show a regular alert message    
                alertText: "簡單說明不可以超過100個字.", // Text in alert message   
                slider: false // True Use counter slider    
            });
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
<div class="clear"></div>
    <uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="i-post" isCloseImageTab="True"  isCloseLinkTab="True" />
    <div class="clear"></div>
 <table width="100%" class="from_table_2">
<tr>

    <th scope="col">標　　題</th>
    <td ><asp:TextBox ID="title" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'標題必填'}}}"></asp:TextBox></td>
  </tr>
 <tr>

    <th scope="col">扼要內容</th>
    <td >
      <asp:TextBox ID="shortDescription" runat="server" Width="450px" TextMode="MultiLine"
                    Height="50px" MaxLength="100" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
    </td>
  </tr>
 <tr>

    <th scope="col">內　　容</th>
    <td >
     <asp:TextBox ID="article" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
    </td>
  </tr>

                     </table>
<div class="bottom_btn">
             <asp:Button ID="InsertButton" runat="server" Text="修正" CssClass="btn_small" OnClick="InsertButton_Click">
        </asp:Button>
           
             <input class="btn_small" type="button" value="取消"  onclick="javascript: history.back();"  />
        </div>
</asp:Content>

