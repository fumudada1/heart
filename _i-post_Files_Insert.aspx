<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_i-post_Files_Insert.aspx.cs" Inherits="_i_post_Files_Insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="background:none;>
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/layouts/2_col_liquid_no_constraint.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/text/text_n_colors.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <legend>新增附加檔案</legend>
        
<div style="display:inherit;text-align: left;"><asp:label ID="lblfileName" runat="server" AssociatedControlID="fileName">檔案名稱</asp:label><asp:TextBox ID="fileName" runat="server" width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox></div>
<div style="display:inherit;text-align: left;"><asp:label ID="lblfileUrl" runat="server" AssociatedControlID="fileUrl">檔案</asp:label><asp:DropDownList
                ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                <asp:ListItem>檔案上傳</asp:ListItem>
                <asp:ListItem>檔案連結</asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="fileUrl" runat="server" />
            <asp:TextBox ID="fileUrlPath" runat="server" Width="250px" Visible="False" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox></div>
       
        <div class="bottom_btn">
    <asp:Button ID="btnADD" runat="server" Text="加入" onclick="btnADD_Click" CssClass="button" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</div> 
    </fieldset>
    
    </form>
</body>
