<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModuleAuto.aspx.cs" Inherits="manage_ModuleAuto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>無與倫比的模組程式原型三代</title>
</head>
<body>
    <form id="form1" runat="server">
   <div>

        <table border="1" cellpadding="0" cellspacing="0" width="600" class="Table2Class4" align="center">
            <tr>
                <th colspan="4">無與倫比的模組程式原型3代</th>
            </tr>
            <tr>
                <td class="Alter">
                    &nbsp;模組代號：</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtModuleID" runat="server"></asp:TextBox>
                </td>
                <td class="Alter">
                    &nbsp;型態：</td>
                <td align="right">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="1">分頁搜尋</asp:ListItem>
                        <asp:ListItem Value="0">自訂排序</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="Alter">
                    &nbsp;模組英文名稱：</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtModuleName" runat="server"></asp:TextBox></td>
                <td class="Alter">
                    &nbsp;模組中文名稱：</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtCName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="建立管理後台" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="建立前台瀏覽" onclick="Button2_Click" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
