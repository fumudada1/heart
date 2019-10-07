<%@ Page ValidateRequest="false" Title="編輯" Language="C#" MasterPageFile="~/Sys/MasterPage.master"
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
                alertText: "簡單說明不可以超過100個字.", // Text in alert message   
                slider: false // True Use counter slider    
            });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="News" isCloseImageTab="True" isCloseArticleTab="True" />
    <h3>
        基本資料維護
    </h3>
    <table class="from_table">
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbltitle" runat="server" AssociatedControlID="title">主題</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="title" runat="server" Width="550px" CssClass="{validate:{required:true, messages:{required:'標題必填'}}}"></asp:TextBox>
            </td>
        </tr>

        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblpicUrl" runat="server" AssociatedControlID="picUrlLink">圖片</asp:Label>
            </th>
            <td>
                <asp:FileUpload ID="fuPic" runat="server" />
                <asp:HyperLink ID="picUrlLink" runat="server" Target="_blank">檢視圖片</asp:HyperLink>
            </td>
        </tr>
       
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblstartDate" runat="server" AssociatedControlID="startDate">開始日期</asp:Label>
            </th>
            <td class="datepicker">
                <asp:TextBox ID="startDate" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'開始日期必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblendDate" runat="server" AssociatedControlID="endDate">結束日期</asp:Label>
            </th>
            <td class="datepicker">
                <asp:TextBox ID="endDate" runat="server" Width="250px" CssClass="{validate:{date:true, messages:{date:'結束日期格式不正確'}}}"></asp:TextBox>(不設定代表永遠生效)
            </td>
        </tr>
         <tr style="display: inherit" class="max">
            <th>
                <asp:Label ID="lblshortDescription" runat="server" AssociatedControlID="shortDescription">請扼要說明內容(100字)</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="shortDescription" runat="server" Width="550px" TextMode="MultiLine"
                    Height="50px" MaxLength="100" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>

        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblarticle" runat="server" AssociatedControlID="article">詳細內容</asp:Label>
            </th>
            <td style="clear: both">
                <asp:TextBox ID="article" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>


    </table>
    <%--不顯示欄位--%>
    <asp:Panel ID="pnlHidden" runat="server" Visible="false">
        
        <table>
                           <tr style="display: inherit">
            <th>
                <asp:Label ID="lblOrgID" runat="server" AssociatedControlID="ddlOrg">機關</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlOrg" runat="server" DataTextField="title" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>

            <tr style="display: inherit">
            <th>
                <asp:Label ID="lblclassID" runat="server" AssociatedControlID="ddlClass1">類別</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlClass1" runat="server" DataTextField="className" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>

                    

        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblfileUrl" runat="server" AssociatedControlID="fileUrl">檔案</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                    <asp:ListItem>檔案連結</asp:ListItem>
                    <asp:ListItem>檔案上傳</asp:ListItem>
                </asp:DropDownList>
                <asp:FileUpload ID="fuFile" runat="server" Visible="False" />
                <asp:TextBox ID="fileUrl" runat="server" Width="250px"></asp:TextBox>
                <asp:HyperLink ID="fileUrlLink" runat="server" Target="_blank">下載檔案</asp:HyperLink>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllinkUrl" runat="server" AssociatedControlID="linkUrl">連結</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="linkUrl" runat="server" Width="250px"></asp:TextBox>
                <asp:DropDownList ID="linkTarget" runat="server">
                    <asp:ListItem Value="_blank">另開新視窗</asp:ListItem>
                    <asp:ListItem Value="_self">在當前視窗開啟</asp:ListItem>
                </asp:DropDownList>
                (外連結請加http://)
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllinkText" runat="server" AssociatedControlID="linkText">連結說明文字</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="linkText" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblposter" runat="server" AssociatedControlID="poster">張貼者</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="poster" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblposterUnit" runat="server" AssociatedControlID="posterUnit">張貼者單位</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="posterUnit" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblupdater" runat="server" AssociatedControlID="updater">最後更新者</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="updater" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblupdaterUnit" runat="server" AssociatedControlID="updaterUnit">最後更新單位</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="updaterUnit" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllastupdated" runat="server" AssociatedControlID="lastupdated">最後更新時間</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="lastupdated" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblcounts" runat="server" AssociatedControlID="counts">點閱數</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="counts" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'必填', number:'須為數字'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbllistNum" runat="server" AssociatedControlID="listNum">排序</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="listNum" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'必填', number:'須為數字'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lbleable" runat="server" AssociatedControlID="eable">顯示狀態</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="eable" runat="server">
                    <asp:ListItem Value="True">是</asp:ListItem>
                    <asp:ListItem Value="False">否</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblbeSelect" runat="server" AssociatedControlID="beSelect">是否置頂</asp:Label>
            </th>
            <td>
                <asp:DropDownList ID="beSelect" runat="server">
                    <asp:ListItem Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: inherit">
            <th>
                <asp:Label ID="lblstatus" runat="server" AssociatedControlID="status">狀態</asp:Label>
            </th>
            <td>
                <asp:TextBox ID="status" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        </table>

    </asp:Panel>
    <div class="bottom_btn">
        <asp:Button ID="InsertButton" runat="server" Text="確定" CssClass="button" OnClick="InsertButton_Click">
        </asp:Button>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="再發一次信" />
        <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'"
            type="button" value="回列表" class="button" />
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
</asp:Content>
