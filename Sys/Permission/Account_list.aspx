<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Account_list.aspx.cs" Inherits="A01Permission_Account_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="top_control">
       <asp:HyperLink ID="lnkAddAdmin" runat="server" NavigateUrl="Account_Insert.aspx">新增管理者</asp:HyperLink>
          </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="id"  CssClass="tableStyle1"
        onrowdeleting="GridView1_RowDeleting" Width="100%" GridLines="None" 
    EnableModelValidation="True" onrowdatabound="GridView1_RowDataBound" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="account" HeaderText="帳號" 
                SortExpression="account" />
            <asp:TemplateField HeaderText="姓名" SortExpression="name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                    <asp:HyperLink
                            ID="HyperLink1" runat="server" NavigateUrl='<%# "Role_Mapping.aspx?RoleID=" + Eval( "id") %>'
                            Text='<%# Eval( "name") %>' Visible="False"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
            <asp:BoundField DataField="Organization" HeaderText="單位/描述" 
                SortExpression="Organization" />
            <asp:TemplateField HeaderText="編輯">
            <ItemTemplate><asp:HyperLink ID="lnkEdit"  runat="server" CssClass="action" 
                    title="編輯" ImageUrl="~/Sys/images/Modify.gif" 
                    NavigateUrl='<%# "Account_Edit.aspx?id=" + Eval("id") %>' ></asp:HyperLink></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="刪除">
            <ItemTemplate>
            <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="~/Sys/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

