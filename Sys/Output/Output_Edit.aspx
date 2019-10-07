<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="Output_Edit.aspx.cs" Inherits="Sys_Output_Output_Edit" %>

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
            $('.max textarea').maxlength({
                maxCharacters: 500, // Characters limit      

                notificationClass: "notification", // Will be added when maxlength is reached  
                showAlert: true, // True to show a regular alert message    
                alertText: "簡單說明不可以超過500個字.", // Text in alert message   
                slider: false // True Use counter slider    
            });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        編輯</h3>
    <table class="from_table">
        <tr>
            <th>
                活動名稱
            </th>
            <td>
                &nbsp;<asp:TextBox ID="subject" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
 <tr>
            <th>
                支出金額
            </th>
            <td>
                &nbsp;<asp:TextBox ID="coco" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                活動日期
            </th>
            <td class="datepicker">
                &nbsp;<asp:TextBox ID="activityDate" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                活動內容
            </th>
            <td>
                &nbsp;<asp:TextBox ID="article" runat="server" Width="250px"  CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="UpdateButton" runat="server" Text="更新" 
                    onclick="UpdateButton_Click1"></asp:Button><input type="button"
                    value="回上頁" onclick="history.back();" />
            </td>
        </tr>
    </table>
</asp:Content>
