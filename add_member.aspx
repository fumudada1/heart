<%@ Page Title="" Language="C#"  MasterPageFile="~/Heart.master" AutoEventWireup="true"
    CodeFile="add_member.aspx.cs" Inherits="add_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker.js") %>"></script>
     <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker-zh-TW.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/pagination.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.core.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.datepicker.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.theme.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/twzipcode-1.3.1.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $('.zipcode').twzipcode({
                zipSel: "800",
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-10y" });
            $('#btnCheckAccount').click(function () {
                if ($(".username").val() == "") return;
                $.get('Ashx/CheckAccount.ashx', { username: $(".username").val() }, function (data) {
                    if (data == "1") {
                        $("#checkmessage").text("帳號已經存在，請使用其他帳號名稱！");
                    } else {
                        $("#checkmessage").text("此帳號可以使用！");
                    }
                });

            });
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <h1>加入會員</h1>
    <div class="memeber_list">
        <table class="from_table_2">
            <tr>
                <th>
                    <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">*帳　　號</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="username" runat="server" Width="150px" CssClass="username {validate:{required:true, messages:{required:'帳號必填'}}}"></asp:TextBox><input
                        id="btnCheckAccount" type="button" value="檢查帳號" /><span id="checkmessage" style="color: red"></span>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">*密　　碼</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="password" runat="server" Width="150px" CssClass="password {validate:{required:true, messages:{required:'密碼必填'}}}"
                        TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtPassword">*確認密碼</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="150px" CssClass="{validate:{required:true, equalTo:'.password', messages:{required:'密碼必填', equalTo:'密碼輸入不相同'}}}"
                        TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblname" runat="server" AssociatedControlID="name">*姓　　名</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="name" runat="server" Width="150px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <th>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="aliasName">*暱　　稱</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="aliasName" runat="server" Width="150px" CssClass="{validate:{required:true, messages:{required:'暱稱必填'}}}"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">*性　　別</asp:Label>
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
                    <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">*聯絡E-mail</asp:Label>
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
                    <input type="text" id="areaCode" style="width: 30px" value="" runat="server" 
                        maxlength="3" />
                    <input type="text" id="numberCode" style="width: 210px" value="" runat="server"
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
                </td>
            </tr>
        </table>
        <div class="bottom_btn">
            <asp:Button CssClass="btn_small" ID="InsertButton" runat="server" Text="確定" OnClick="InsertButton_Click">
            </asp:Button>
            <input class="btn_small" type="button" value="回上頁" onclick="javascript:history.back();" />
        </div>
    </div>
</asp:Content>
