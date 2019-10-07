<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="Input_Insert.aspx.cs" Inherits="Sys_Input_Input_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker-zh-TW.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.maxlength-min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/webEditor/ckeditor/ckeditor.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.core.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.datepicker.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.theme.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/maxlength.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $(".datepicker input").datepicker();
            
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        新增</h3>
    <table class="from_table">
        <tr>
            <th>
                暱 稱
            </th>
            <td>
                &nbsp;<asp:DropDownList ID="ddlCustomer" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                金額
            </th>
            <td>
                &nbsp;<asp:TextBox ID="coco" runat="server" Width="250px" CssClass="{validate:{required:true,digits:true, messages:{required:'金額必填',digits:'請填數字'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                匯款帳號後五碼
            </th>
            <td>
                &nbsp;<asp:TextBox ID="bankNumber" runat="server" Width="250px" MaxLength="5" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                匯款日期
            </th>
            <td class="datepicker">
                &nbsp;<asp:TextBox ID="payDate" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                審核
            </th>
            <td>
                &nbsp;<asp:DropDownList ID="enable" runat="server">
                    <asp:ListItem Value="True">通過</asp:ListItem>
                    <asp:ListItem Value="False">未通過</asp:ListItem>
                </asp:DropDownList>
              
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="InsertButton" runat="server" Text="新增" 
                    onclick="InsertButton_Click"></asp:Button><input type="button"
                    value="回上頁" onclick="history.back();" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
