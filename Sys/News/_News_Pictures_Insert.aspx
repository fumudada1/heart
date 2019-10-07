<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_News_Pictures_Insert.aspx.cs" Inherits="manage_News_News_Pictures_Insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
        <legend>新增附加圖片</legend>
        
<div style="display:inherit;text-align: left;"><asp:label ID="lblpicName" runat="server" AssociatedControlID="picName">圖片說明</asp:label><asp:TextBox ID="picName" runat="server" width="250px" CssClass="{validate:{required:true, messages:{required:'說明必填'}}}"></asp:TextBox></div>
<div style="display:inherit;text-align: left;"><asp:label ID="lblpicUrl" runat="server" AssociatedControlID="picUrl">圖片</asp:label>
            <asp:FileUpload ID="fuPic" runat="server" />
</div>
       
         <div style="background-color:Green;color:White;font-weight:bold;margin-top:20px;">
    <asp:Button ID="btnADD" runat="server" Text="加入" onclick="btnADD_Click" CssClass="button" />
             <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</div> 
    </fieldset>
    </form>
</body>
