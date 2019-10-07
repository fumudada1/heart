<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmailTemplat_Edit.aspx.cs" Inherits="Sys_EmailTemplat_EmailTemplat_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker-zh-TW.js") %>"></script>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $(".datepicker input").datepicker();
        });
               
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        編輯 E-mail 樣版</h3>
    <table class="from_table">
        <tr>
            <th>
               代號
            </th>
            <td>
                &nbsp;<asp:TextBox ID="number" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                主題
            </th>
            <td>
                &nbsp;<asp:TextBox ID="subject" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                E-mail 樣版
            </th>
            <td>
                &nbsp;<asp:TextBox ID="article" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="UpdateButton" runat="server" Text="更新" 
                    onclick="UpdateButton_Click"></asp:Button><input type="button"
                    value="回上頁" onclick="history.back();" />
            </td>
        </tr>
    </table>
</asp:Content>
