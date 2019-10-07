<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="_i-post_Files.aspx.cs" Inherits="_i_post_Files" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/thickbox.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.tablednd.0.5.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/thickbox.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $("table").tableDnD({
                onDragClass: "showDragHandle",
                onDrop: function (table, row) {
                    var rows = table.tBodies[0].rows;
                    for (var i = 0; i < rows.length; i++) {
                        $(rows[i]).find(".position").val(i);
                    }
                }
            });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>團員專區</h1>
 <div class="member_btn">
<a class="member_btn_1" href="member_person.aspx" title="修改團員資料"></a>
<a class="member_btn_2"  href="donation_person.aspx" title="善款明細記錄"></a>
<a class="member_btn_4_1"  href="i-post.aspx" title="發表團員分享"></a>
<a class="member_btn_3"  href="i-donation.aspx" title="捐贈登錄"></a>

</div>
   <div class="clear"></div>
    <uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="i-post" isCloseImageTab="True"  isCloseLinkTab="True" />
    <div class="clear"></div> 
    <p style=" text-indent:0;padding:0;">
        <a href="<%=String.Format("_i-post_Files_Insert.aspx?publishID={0}&ModuleID={1}&KeepThis=true&TB_iframe=true&height=400&width=600", Request["ID"], Request["ModuleID"]) %>"
            title="新增附加檔案" class="thickbox">新增附加檔案</a>
    </p>
 
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="id" OnRowDataBound="gvList_RowDataBound" OnRowDeleting="gvList_RowDeleting" CssClass="tableStyle1">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="fileName" HeaderText="檔案說明" SortExpression="fileName" />
            <asp:TemplateField HeaderText="檔案" SortExpression="fileUrl">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# My.WebForm.ConverInsideLink(Eval("fileUrl"), "~/UploadFiles/Files/",false) %>'
                        Text='<%# Eval("fileName") %>' Target="_blank"></asp:HyperLink>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fileUrl") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="原始排序" SortExpression="listNum">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("listNum") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("listNum") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="新排序">
                <ItemTemplate>
                    <asp:TextBox ID="listNum" runat="server" CssClass="position {validate:{required:true,number:true, messages:{required:'新排序必填',number:'須為數字'}}}"
                        Width="40px" Text='<%# Eval("listNum") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="編輯">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkEdit" runat="server" CssClass="thickbox" title="編輯附加連結">編輯</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" HeaderText="刪除" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" CssClass="nodrop nodrag" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <div class="bottom_btn">
        <asp:Button ID="btnSure" runat="server" Text="更新排序" CssClass="button" OnClick="btnSure_Click" />
        <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>    &page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>    '"
            type="button" value="回列表" class="button" />
    </div>
</asp:Content>

