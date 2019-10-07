<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="manage_A01Permission_ModifyPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
請輸入你的新密碼:<asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Button ID="btnSure" runat="server" Text="確定" onclick="btnSure_Click" />
</asp:Content>

