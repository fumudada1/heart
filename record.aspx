<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="record.aspx.cs" Inherits="record" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>雲施紀錄</h1>
 <div class="donation_btn">
 	<a href="record.aspx" class="donation_btn_1_1"></a>
 	<a href="record1.aspx" class="donation_btn_2"></a>
 	<a href="donation.aspx" class="donation_btn_3"></a>
 </div>
 <div class="clear"></div>
    <asp:GridView ID="GridView1" runat="server" CssClass="tableStyle1" AllowSorting="True" AutoGenerateColumns="False" EnableModelValidation="True" OnSorting="GridView1_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="暱稱" SortExpression="aliasName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("aliasName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("aliasName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="捐贈日期" SortExpression="payDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("payDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("payDate", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="coco" HeaderText="捐贈金額" DataFormatString="{0:C0}" />
        </Columns>
        
    </asp:GridView>
     <div class="paging">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
        <div style="text-align:right">
        善款總金額：<asp:Label ID="lblInput" runat="server" Text="0"></asp:Label>　總支出：<asp:Label ID="lblOutput" runat="server" Text="0"></asp:Label>
		 　<span style="color:blue">結餘：<asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label></span>
    </div>
    <div>
       
    </div>
</asp:Content>

