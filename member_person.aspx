<%@ Page Title="" Language="C#"  MasterPageFile="~/Heart.master" AutoEventWireup="true"
    CodeFile="member_person.aspx.cs" Inherits="member_person" %>

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
                zipSel: $('#hidzip').children().val(),
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-10y" });
        });
    </script>
<script>
    $(function () {
        $(".leftmenu_5").addClass('hover_yes');
    })
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
        <h1>團員專區</h1>
<div class="member_btn">
<a class="member_btn_1_1" href="member_person.aspx" title="修改團員資料"></a>
<a class="member_btn_2"  href="donation_person.aspx" title="善款明細記錄"></a>
<a class="member_btn_4"  href="i-post.aspx" title="發表團員分享"></a>
<a class="member_btn_3"  href="i-donation.aspx" title="捐贈登錄"></a>

</div>
        <!--功能選單 結束 -->

            <table width="0" border="0 "  class="from_table_2">
                <tr>
                    <th width="25%">
                        <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號：</asp:Label>
                    </th>
                    <td width="75%">
                        <asp:Label ID="username" runat="server"></asp:Label>
                    </td>
                   
                </tr>
                     <tr>
                    <th >
                        <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">修改密碼：</asp:Label>
                        
                    </th>
                    <td>
                        <asp:TextBox ID="password" runat="server" Width="150px" CssClass="password"
                    TextMode="Password"></asp:TextBox>(密碼已經加密，不修改請保持空白)
                    </td>
                   
                </tr>
                        <tr>
                    <th >
                          <asp:Label ID="lblname" runat="server" AssociatedControlID="name">*姓　　名：</asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="name" runat="server" Width="150px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"
                    MaxLength="50"></asp:TextBox>
                    </td>
                   
                </tr>
                      <tr>
                <th>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="aliasName">*暱　　稱：</asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="aliasName" runat="server" Width="150px" CssClass="{validate:{required:true, messages:{required:'暱稱必填'}}}"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
                 <tr>
                    <th>
                        <asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">*性　　別：</asp:Label>
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
                      <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">*電子信箱：</asp:Label>
                       
                    </th>
                    <td>
                         <asp:TextBox ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox>
                  
                    </td>
                   
                </tr>

                   <tr>
                    <th >
                      <asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日：</asp:Label>
                    </th>
                    <td class="datepicker">
                        <asp:TextBox ID="birthday" runat="server" Width="150px"></asp:TextBox>
                    </td>
                   
                </tr>
                  <tr>
                    <th>
                     <asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="numberCode">電　　話：</asp:Label>
                    </th>
                    <td>
                       <input type="text" id="areaCode" style="width: 30px" value="" runat="server"  maxlength="3"/>
                <input type="text" id="numberCode" style="width: 114px" value="" runat="server" maxlength="8" />
                    </td>
                   
                </tr>
                  <tr>
                    <th>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="cellphone">行動電話：</asp:Label>
                    </th>
                    <td>
                       <asp:TextBox ID="cellphone" runat="server" MaxLength="10"  Width="150px"></asp:TextBox>
                    </td>
                   
                </tr>
                 
                  <tr>
                    <th>
                      <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address">地　　址：</asp:Label>
                   
                    </th>
                    <td>
                        <span class="zipcode"></span>
                <input type="text" id="address" style="width: 210px" value="" runat="server" maxlength="50" />
                    <span id="hidzip">
                    <asp:HiddenField ID="hidzip" runat="server" />
                    </span>
                    </td>
                   
                </tr>
                 
               
            </table>
     
        <div class="bottom_btn">
            <asp:Button CssClass="btn_small" ID="InsertButton" runat="server" Text="修改儲存" 
            onclick="InsertButton_Click" ></asp:Button>
        </div>
  
</asp:Content>
