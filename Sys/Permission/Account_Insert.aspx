<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="Account_Insert.aspx.cs" Inherits="A01Permission_Account_Insert" %>

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
            //            $.validator.addMethod("password", function (value, element) {
            //                return this.optional(element) || /^(?=.*[\d])(?=.*[a-zA-Z])[\w\d\-\*\$!@_]{6,10}$/i.test(value);
            //            }, "密碼格式錯誤");


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
    <h3>
        新增</h3>
    <table class="from_table">
        <tr style="display: inherit" runat="server" id="trRole">
            <th>
                <asp:Label ID="lblRole" runat="server" AssociatedControlID="OrganizationID">角色</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblaccount" runat="server" AssociatedControlID="account">帳號</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="account" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">密碼</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="password" runat="server" Width="250px" CssClass="{validate:{required:true,rangelength:[6,10] , messages:{required:'必填', rangelength:'需輸入6~10個字元'}}} pwd"
                    TextMode="Password"></asp:TextBox>
                需輸入6~10個字元
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblcpassword" runat="server" AssociatedControlID="cpassword">確認密碼</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="cpassword" runat="server" Width="250px" CssClass="{validate:{required:true,rangelength:[6,10],equalTo:'.pwd' , messages:{required:'必填', rangelength:'需輸入6~10個字元',equalTo:'密碼不同'}}}"
                    TextMode="Password"></asp:TextBox>
                需輸入6~10個字元
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓名</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblemail" runat="server" AssociatedControlID="email">E-mail</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="email" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbljobTitle" runat="server" AssociatedControlID="jobTitle">職稱</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="jobTitle" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit" runat="server" id="trUnit">
            <th>
                <asp:Label ID="lblgroupBy" runat="server" AssociatedControlID="OrganizationID">單位</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="OrganizationID" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <fieldset>
        <legend>選取權限</legend>
        <uc1:PermissionUserControl ID="PermissionUserControl1" runat="server" permissionString="" />
    </fieldset>
    <div style="text-align: center" class="bottom_btn">
        <asp:Button ID="InsertButton" runat="server" Text="新增" OnClick="InsertButton_Click">
        </asp:Button><input type="button" value="回上頁" onclick="location='Account_list.aspx'" /></div>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
</asp:Content>
