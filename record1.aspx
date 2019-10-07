<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="record1.aspx.cs" Inherits="record1" %>

<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <h1>雲施紀錄</h1>
  <div class="donation_btn">
 	<a href="record.aspx" class="donation_btn_1"></a>
 	<a href="record1.aspx" class="donation_btn_2_1"></a>
 	<a href="donation.aspx" class="donation_btn_3"></a>
 </div>   <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table width="100%" class="tableStyle1">
            <tr>
                <th scope="col">活動日期</th>
                <th scope="col">活動名稱</th>
                <th scope="col">金額</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("activityDate", "{0:d}") %>'></asp:Label></td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("subject") %>' NavigateUrl='<%# "record1_Detail.aspx?id=" + Eval("id") %>'></asp:HyperLink>
              
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("coco", "{0:C0}") %>'></asp:Label></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
    </table>
    </FooterTemplate>
</asp:Repeater>
     <div class="paging">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
       <div style="text-align:right">
        善款總金額：<asp:Label ID="lblInput" runat="server" Text="0"></asp:Label>　總支出：<asp:Label ID="lblOutput" runat="server" Text="0"></asp:Label>
		 　<span style="color:blue">結餘：<asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label></span>
    </div>
</asp:Content>

