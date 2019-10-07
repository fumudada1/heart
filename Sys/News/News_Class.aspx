<%@ Page Title="-���O���@" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="News_Class.aspx.cs" Inherits="manage_News_News_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.5.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/thickbox.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.tablednd.0.5.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    
        <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/thickbox.css") %>" rel="stylesheet"
        type="text/css" />
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
<div>
    �s�W���O:<asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server"
        Text="�T�w" onclick="btnAdd_Click" />
        <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button" value="�^�C��" />
   </div>    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" 
        EnableModelValidation="True" CssClass="tableStyle1" GridLines="None" 
        onrowdatabound="GridView1_RowDataBound" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="�W��" SortExpression="className">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("className") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("className") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="��l�Ƨ�" SortExpression="className">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("listNum") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�s�Ƨ�">
                    <ItemTemplate>
                        <asp:TextBox ID="listNum" runat="server" CssClass="position {validate:{required:true,number:true, messages:{required:'�s�Ƨǥ���',number:'�����Ʀr'}}}" Width="40px" 
                            Text='<%# Eval("listNum") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:CommandField HeaderText="�s��" ShowEditButton="True" />
            <asp:CommandField HeaderText="�R��" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <div>
 <asp:Button ID="btnSure" runat="server" Text="��s�Ƨ�" CssClass="button" 
                onclick="btnSure_Click" /> (�Щ즲���Ƨ�)
                </div>
</asp:Content>

