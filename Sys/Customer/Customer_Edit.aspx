<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Customer_Edit.aspx.cs" Inherits="Sys_Customer_Customer_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/twzipcode-1.3.1.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $('.zipcode').twzipcode({
                zipSel: $('#hidzip').children().val(),
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-10y" });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        修改會員資料
    </h3>
    <table class="from_table">
        <tr>
            <th>
                <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label>
            </th>
            <td>
                <asp:Label ID="username" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">密　　碼</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="password" runat="server" Width="250px" CssClass="password"
                    TextMode="Password"></asp:TextBox>（密碼已經加密，若不修改請勿填寫。）
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓　　名</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"
                    MaxLength="50"></asp:TextBox>
            </td>
        </tr>
          <tr>
                <th>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="aliasName">暱　　稱</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="aliasName" runat="server" Width="150px" CssClass="{validate:{required:true, messages:{required:'暱稱必填'}}}"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <th>
                <asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">性　　別</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="gender" runat="server">
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="0">女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">聯絡E-mail</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日</asp:Label>
            </th>
            <td class="datepicker">
                <asp:TextBox ID="birthday" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="numberCode">電　　話</asp:Label>
            </th>
            <td>
                <input type="text" id="areaCode" style="width: 30px" value="" runat="server" class="{validate:{required:true,digits:true, messages:{required:'區碼必填',digits:'請填數字'}}}" maxlength="3"/>
                <input type="text" id="numberCode" style="width: 210px" value="" runat="server" class="{validate:{required:true,digits:true, messages:{required:'電話必填',digits:'請填數字'}}}"
                    maxlength="8" />
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="cellphone">行動電話</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="cellphone" runat="server"
                    MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address">地　　址</asp:Label>
            </th>
            <td>
                <span class="zipcode"></span>
                <input type="text" id="address" style="width: 210px" value="" runat="server" 
                    maxlength="50" />
                    <span id="hidzip">
                    <asp:HiddenField ID="hidzip" runat="server" />
                    </span>
            </td>
        </tr>
    </table>
    <div class="bottom_btn">
        <asp:Button CssClass="button" ID="InsertButton" runat="server" Text="確定" 
            onclick="InsertButton_Click" ></asp:Button>
        <input class="button" type="button" value="回上頁" onclick="location.href='Customer_List.aspx?ModuleID=<%= Request["ModuleID"] %>'" />
    </div>
</asp:Content>

