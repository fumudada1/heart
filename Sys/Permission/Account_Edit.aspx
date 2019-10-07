<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="Account_Edit.aspx.cs" Inherits="A01Permission_Account_Edit" %>

<%@ Register Src="../../UserControl/PermissionUserControl.ascx" TagName="PermissionUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
        });
        
            
    </script>
    <style type="text/css">
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_0
        {
            text-decoration: none;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_1
        {
            color: Black;
            font-family: Verdana;
            font-size: 11pt !important;
            margin: 0 0 0 5px;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_2
        {
            padding: 0px 5px 0px 5px;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_3
        {
            font-weight: normal;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_4
        {
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_5
        {
            color: #5555DD;
            text-decoration: underline;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_6
        {
            padding: 0px 0px 0px 0px;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_7
        {
            color: #5555DD;
            text-decoration: underline;
        }
        .ctl00_ContentPlaceHolder1_PermissionUserControl1_TreeView1_8
        {
            color: #5555DD;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <h3>
            編輯</h3>
        <table class="from_table">
            <tr style="display: inherit">
                <th>
                    <asp:Label ID="lblaccount" runat="server" AssociatedControlID="account">帳號</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="account" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'required'}}}"
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: inherit">
                <th>
                    <asp:Label ID="lblpassword" runat="server" AssociatedControlID="Cpassword">password</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="Cpassword" runat="server" Width="250px" TextMode="Password" CssClass="{validate:{rangelength:[6,10], messages:{rangelength:'需輸入6~10個字元'}}}"></asp:TextBox>
                    (密碼已被加密，若不修改密碼請保持空白)(需輸入6~10個字元)
                </td>
            </tr>
            <tr style="display: inherit">
                <th>
                    <asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓名</asp:Label>
                </th>
                <td>
                    <asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'required'}}}"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: inherit">
                <th>
                     <asp:Label ID="lblemail" runat="server" AssociatedControlID="email">E-mail</asp:Label>
                </th>
                <td>
                    <asp:TextBox
                ID="email" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'required'}}}"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: inherit">
                <th>
                    <asp:Label ID="lbljobTitle" runat="server" AssociatedControlID="jobTitle">職稱</asp:Label>
                </th>
                <td>
                    <asp:TextBox
                ID="jobTitle" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: inherit"  runat="server" id="trUnit">
                <th>
                     <asp:Label ID="lblgroupBy" runat="server" AssociatedControlID="OrganizationID">單位</asp:Label>
           
                </th>
                <td>
                     <asp:DropDownList ID="OrganizationID" runat="server">
            </asp:DropDownList>
                </td>
            </tr>
        </table>
        <legend>編輯</legend>
        
        
        <div style="display: inherit; text-align: left;">
            </div>
        <div style="display: inherit; text-align: left;">
           
        </div>
        <fieldset>
            <legend>選取權限</legend>
            <uc1:PermissionUserControl ID="PermissionUserControl1" runat="server" />
        </fieldset>
        <div class="bottom_btn">
            <asp:Button ID="UpdateButton" runat="server" Text="更新" OnClick="UpdateButton_Click">
            </asp:Button><input type="button" value="回上頁" onclick="location='Account_list.aspx'" /></div>
    </fieldset>
</asp:Content>
