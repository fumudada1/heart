<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_News_Links_Insert.aspx.cs" Inherits="manage_News_News_Links_Insert" %>

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
        <legend>�s�W���[�s��</legend>
        <div style="display: inherit; text-align: left;">
            <asp:Label ID="lbllinkName" runat="server" AssociatedControlID="linkName">�s������</asp:Label><asp:TextBox
                ID="linkName" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'�s����������'}}}"></asp:TextBox></div>
        <div style="display: inherit; text-align: left;">
            <asp:Label ID="lbllinkUrl" runat="server" AssociatedControlID="linkUrl">�s�����|</asp:Label><asp:TextBox
                ID="linkUrl" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'�s�����|����'}}}"></asp:TextBox>
            (�~�s���Х[http://)
        </div>
        <div style="display: inherit; text-align: left;">
            <asp:Label ID="lbllinkTarget" runat="server" AssociatedControlID="linkTarget">�}�ҥؼ�</asp:Label>
            <asp:DropDownList ID="linkTarget" runat="server">
                <asp:ListItem Value="_blank">�t�}�s����</asp:ListItem>
                <asp:ListItem Value="_self">�b��e�����}��</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div style="background-color: Green; color: White; font-weight: bold; margin-top: 20px;">
            <asp:Button ID="btnADD" runat="server" Text="�[�J" OnClick="btnADD_Click" CssClass="button" />
        </div>
    </fieldset>
    </form>
</body>
</html>
