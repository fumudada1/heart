<%@ Page Title="" Language="C#"  MasterPageFile="~/Heart.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="Culture_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <img src="images/h1_member.png" /></h1>
    <div class="memeber_list">
        <div class="mgt_login">
            <div class="mgt_writing1">
                <asp:TextBox ID="account" runat="server" CssClass="writing" ToolTip="請輸入帳號"></asp:TextBox>
                </div>
            <div class="mgt_writing2">
                <asp:TextBox ID="Password" TextMode="Password" CssClass="writing" ToolTip="請輸入密碼"
                                    runat="server"></asp:TextBox>
                </div>
            <div class="mgt_writing3">
                <asp:Button ID="btnLogin" runat="server" CssClass="login_btn" 
                    onclick="btnLogin_Click" />
            </div>
            <a href="add_member.aspx" class="mgt_writing4">加入會員</a>
            <div class="ErrorInfo">
                <asp:Label ID="lblErrer" runat="server" Text="登入失敗，請重新輸入帳號/密碼！" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
