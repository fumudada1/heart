<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="Customer_List.aspx.cs" Inherits="Sys_Customer_Customer_list" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        關鍵字<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="搜尋" 
            onclick="btnSearch_Click"  />
        <asp:Button ID="btnReset" runat="server"  Text="重設" onclick="btnReset_Click" />
    </div>
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        Font-Size="14px" Width="90%" onrowdeleting="gvList_RowDeleting" onrowupdating="gvList_RowUpdating" EnableModelValidation="True" CssClass="tableStyle1"
        GridLines="None">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name"></asp:BoundField>
            <asp:BoundField DataField="city" HeaderText="縣市" SortExpression="city" />
            <asp:TemplateField HeaderText="性別" SortExpression="gender">
                <ItemTemplate>
                    <asp:Label ID="lblgender" runat="server" Text='<%# Eval("gender").ToString()=="1"?"男":"女" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="建立日期" SortExpression="initDate" />
            <asp:TemplateField HeaderText="編輯">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" CommandName="Update"
                        ImageUrl="../images/Modify.gif" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                        ImageUrl="../images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="cc_m_listguide">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
</asp:Content>
