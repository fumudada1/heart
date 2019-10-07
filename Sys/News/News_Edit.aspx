<%@ Page ValidateRequest="false" Title="�s��" Language="C#" MasterPageFile="~/Sys/MasterPage.master"
    AutoEventWireup="true" CodeFile="News_Edit.aspx.cs" Inherits="manage_News_News_Edit" %>

<%@ Register Src="../../UserControl/PublishTab.ascx" TagName="PublishTab" TagPrefix="uc2" %>
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
                maxCharacters: 100, // Characters limit      

                notificationClass: "notification", // Will be added when maxlength is reached  
                showAlert: true, // True to show a regular alert message    
                alertText: "²�满�����i�H�W�L100�Ӧr.", // Text in alert message   
                slider: false // True Use counter slider    
            });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="News" isCloseImageTab="True" isCloseArticleTab="True" />
    <h3>
        �򥻸�ƺ��@
    </h3>
    <table class="from_table">
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbltitle" runat="server" AssociatedControlID="title">�D�D</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="title" runat="server" Width="550px" CssClass="{validate:{required:true, messages:{required:'���D����'}}}"></asp:TextBox>
            </td>
        </tr>

        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblpicUrl" runat="server" AssociatedControlID="picUrlLink">�Ϥ�</asp:Label>
            </th>
            <td>
                <asp:FileUpload ID="fuPic" runat="server" />
                <asp:HyperLink ID="picUrlLink" runat="server" Target="_blank">�˵��Ϥ�</asp:HyperLink>
            </td>
        </tr>
       
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblstartDate" runat="server" AssociatedControlID="startDate">�}�l���</asp:Label>
            </th>
            <td class="datepicker">
                <asp:TextBox ID="startDate" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'�}�l�������'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblendDate" runat="server" AssociatedControlID="endDate">�������</asp:Label>
            </th>
            <td class="datepicker">
                <asp:TextBox ID="endDate" runat="server" Width="250px" CssClass="{validate:{date:true, messages:{date:'��������榡�����T'}}}"></asp:TextBox>(���]�w�N��û��ͮ�)
            </td>
        </tr>
         <tr style="display: inherit" class="max">
            <th>
                <asp:Label ID="lblshortDescription" runat="server" AssociatedControlID="shortDescription">�Ч�n�������e(100�r)</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="shortDescription" runat="server" Width="550px" TextMode="MultiLine"
                    Height="50px" MaxLength="100" CssClass="{validate:{required:true, messages:{required:'����'}}}"></asp:TextBox>
            </td>
        </tr>

        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblarticle" runat="server" AssociatedControlID="article">�ԲӤ��e</asp:Label>
            </th>
            <td style="clear: both">
                <asp:TextBox ID="article" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>


    </table>
    <%--��������--%>
    <asp:Panel ID="pnlHidden" runat="server" Visible="false">
        
        <table>
                           <tr style="display: inherit">
            <th>
                <asp:Label ID="lblOrgID" runat="server" AssociatedControlID="ddlOrg">����</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlOrg" runat="server" DataTextField="title" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>

            <tr style="display: inherit">
            <th>
                <asp:Label ID="lblclassID" runat="server" AssociatedControlID="ddlClass1">���O</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlClass1" runat="server" DataTextField="className" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>

                    

        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblfileUrl" runat="server" AssociatedControlID="fileUrl">�ɮ�</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                    <asp:ListItem>�ɮ׳s��</asp:ListItem>
                    <asp:ListItem>�ɮפW��</asp:ListItem>
                </asp:DropDownList>
                <asp:FileUpload ID="fuFile" runat="server" Visible="False" />
                <asp:TextBox ID="fileUrl" runat="server" Width="250px"></asp:TextBox>
                <asp:HyperLink ID="fileUrlLink" runat="server" Target="_blank">�U���ɮ�</asp:HyperLink>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllinkUrl" runat="server" AssociatedControlID="linkUrl">�s��</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="linkUrl" runat="server" Width="250px"></asp:TextBox>
                <asp:DropDownList ID="linkTarget" runat="server">
                    <asp:ListItem Value="_blank">�t�}�s����</asp:ListItem>
                    <asp:ListItem Value="_self">�b��e�����}��</asp:ListItem>
                </asp:DropDownList>
                (�~�s���Х[http://)
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllinkText" runat="server" AssociatedControlID="linkText">�s��������r</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="linkText" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblposter" runat="server" AssociatedControlID="poster">�i�K��</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="poster" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblposterUnit" runat="server" AssociatedControlID="posterUnit">�i�K�̳��</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="posterUnit" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblupdater" runat="server" AssociatedControlID="updater">�̫��s��</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="updater" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblupdaterUnit" runat="server" AssociatedControlID="updaterUnit">�̫��s���</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="updaterUnit" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllastupdated" runat="server" AssociatedControlID="lastupdated">�̫��s�ɶ�</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="lastupdated" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblcounts" runat="server" AssociatedControlID="counts">�I�\��</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="counts" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'����', number:'�����Ʀr'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllistNum" runat="server" AssociatedControlID="listNum">�Ƨ�</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="listNum" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'����', number:'�����Ʀr'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbleable" runat="server" AssociatedControlID="eable">��ܪ��A</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="eable" runat="server">
                    <asp:ListItem Value="True">�O</asp:ListItem>
                    <asp:ListItem Value="False">�_</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblbeSelect" runat="server" AssociatedControlID="beSelect">�O�_�m��</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="beSelect" runat="server">
                    <asp:ListItem Value="0">�_</asp:ListItem>
                    <asp:ListItem Value="1">�O</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblstatus" runat="server" AssociatedControlID="status">���A</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="status" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        </table>

    </asp:Panel>
    <div class="bottom_btn">
        <asp:Button ID="InsertButton" runat="server" Text="�T�w" CssClass="button" OnClick="InsertButton_Click">
        </asp:Button>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="�A�o�@���H" />
        <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'"
            type="button" value="�^�C��" class="button" />
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
</asp:Content>
