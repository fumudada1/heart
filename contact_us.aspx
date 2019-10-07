<%@ Page Title="" Language="C#"  MasterPageFile="~/Heart.master" AutoEventWireup="true"
    CodeFile="contact_us.aspx.cs" Inherits="Culture_contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <img src="images/h1_contus.png" /></h1>
    <div class="common">
        <table class="from_table_2">
            <tr>
                <th>
                    <asp:Label ID="lblAllName" runat="server" AssociatedControlID="allName">＊您的姓名</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="allName" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblGender" runat="server" AssociatedControlID="gender">＊稱　　謂</asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="gender" runat="server">
                        <asp:ListItem Value="1">先生</asp:ListItem>
                        <asp:ListItem Value="0">小姐</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblEmailAddress" runat="server" AssociatedControlID="emailAddress">＊電子郵件</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="emailAddress" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPhoneNumber" runat="server" AssociatedControlID="phoneNumber">＊聯絡電話</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="phoneNumber" runat="server" Width="250px" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblQuestionClass" runat="server" AssociatedControlID="ddlQuestionClass">＊問題類別</asp:Label>
                    
                </th>
                <td>
                    <asp:DropDownList ID="ddlQuestionClass" runat="server">
                        <asp:ListItem Value="產品報價">產品報價</asp:ListItem>
                        <asp:ListItem Value="送貨事宜">送貨事宜</asp:ListItem>
                        <asp:ListItem Value="其他">其他</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblArticle" runat="server" AssociatedControlID="article">＊聯絡內容</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="article" runat="server" TextMode="MultiLine" Height="250px" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtVCode">＊圖形驗證</asp:Label>
                </th>
                <td>
                    <font size="-1">
                        <img alt="請輸入圖中所顯示的英數字" border="1" align="middle" title="請輸入圖中所顯示的英數字" id="imgMVcode"
                            runat="server" />
                    </font>
                    <asp:TextBox ID="txtVCode" runat="server" BackColor="#FFFF99" onblur="javascript: if(this.value=='')  this.value='請輸入驗證碼';"
                        onfocus="javascript: if(this.value=='請輸入驗證碼') this.value='';" Text="請輸入驗證碼" Width="200px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="bottom_btn">
        <asp:Button ID="Button1" runat="server" Text="送出" onclick="Button1_Click" />
    </div>
</asp:Content>
