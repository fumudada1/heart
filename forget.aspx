<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="forget.aspx.cs" Inherits="forget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1><img src="images/h1_forget.png" /></h1>

          <h2>請輸入您的帳號與E-mail</h2>
          <div class="memeber_list">
            <table class="from_table_3">
              <tr>
                <th> <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="username" runat="server" Width="250px" CssClass="username {validate:{required:true, messages:{required:'帳號必填'}}}"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                    <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">原E-mail</asp:Label>
                </th>
                <td><asp:TextBox ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox></td>
              </tr>
            </table>
            <div class="bottom_btn">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
                <asp:Button ID="SureButton" runat="server" Text="確定" class="btn_small" 
                    onclick="SureButton_Click"/>
              <input class="btn_small" type="button" value="回上頁" onclick="javascript:history.back();" />
            </div>
          </div>
</asp:Content>

