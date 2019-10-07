<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="donation_person.aspx.cs" Inherits="donation_person" %>

<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>團員專區</h1>
    <div class="member_btn">
        <a class="member_btn_1" href="member_person.aspx" title="修改團員資料"></a>
        <a class="member_btn_2_1" href="donation_person.aspx" title="善款明細記錄"></a>
        <a class="member_btn_4" href="i-post.aspx" title="發表團員分享"></a>
        <a class="member_btn_3" href="i-donation.aspx" title="捐贈登錄"></a>

    </div>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="100%" class="tableStyle1">

                <tbody>
                    <tr>

                        <th scope="col">捐贈日期</th>
                        <th scope="col">捐贈金額</th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>

                <td><asp:Label ID="lblinitDate" runat="server" Text='<%# Eval("initDate","{0:yyyy/MM/dd}") %>'></asp:Label></td>
                <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("coco","{0:C0}") %>'></asp:Label></td>
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
</asp:Content>

