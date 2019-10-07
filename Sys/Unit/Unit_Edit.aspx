<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true"
    CodeFile="Unit_Edit.aspx.cs" Inherits="Sys_Unit_Unit_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        編輯</h3>
    <table class="from_table">
        <tr>
            <th>
                名稱
            </th>
            <td>
                &nbsp;<asp:TextBox ID="title" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                代號
            </th>
            <td>
                &nbsp;<asp:TextBox ID="asName" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="UpdateButton" runat="server" Text="更新" 
                    onclick="UpdateButton_Click"></asp:Button><input type="button"
                    value="回上頁" onclick="history.back();" />
            </td>
        </tr>
    </table>
</asp:Content>
