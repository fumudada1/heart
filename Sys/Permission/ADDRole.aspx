<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="ADDRole.aspx.cs" Inherits="manage_A01Permission_ADDRole" %>
<%@ Register Src="~/UserControl/PermissionUserControl.ascx" TagName="PermissionUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset>
        <legend>新增角色</legend>
        <label>
            角色名稱</label>&nbsp;<asp:TextBox ID="roleName" runat="server" Width="250px"></asp:TextBox><br />
        <label>
            角色描述</label>&nbsp;<asp:TextBox ID="description" runat="server" Width="250px"></asp:TextBox><br />
           
    </fieldset>
    <fieldset>
        <legend style="color: Green;">選取角色權限</legend>
        <uc1:PermissionUserControl ID="PermissionUserControl2" runat="server" permissionString="" />
    </fieldset>
    <div style="background-color: Green; color: White; font-weight: bold;">
        <asp:Button ID="btnUpdate" runat="server" Text="確定" CssClass="button" 
            onclick="btnUpdate_Click" />
        <asp:Button ID="btnList" runat="server" Text="回上頁" CssClass="button" 
            onclick="btnList_Click" />
    </div>
</asp:Content>

