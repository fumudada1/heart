<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Role_ADD.aspx.cs" Inherits="manage_A01Permission_Role_ADD" %>
<%@ Register Src="~/UserControl/PermissionUserControl.ascx" TagName="PermissionUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_0 { text-decoration:none; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_1 { color:Black;font-family:Verdana;font-size:11pt !important; margin:0 0 0 5px; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_2 { padding:0px}
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_3 { font-weight:normal; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_4 {  }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_5 { color:#5555DD;text-decoration:underline; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_6 { padding:0px 0px 0px 0px; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_7 { color:#5555DD;text-decoration:underline; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_8 { color:#5555DD;text-decoration:underline; }

</style>
<style type="text/css"> 
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_0 { text-decoration:none; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_1 { color:Black;font-family:Verdana;font-size:11pt !important; margin:0 0 0 5px; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_2 { padding:0 0 5px 0 !important;  }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_3 { font-weight:normal; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_4 {  }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_5 { color:#5555DD;text-decoration:underline; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_6 { padding:0px 0px 0px 0px; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_7 { color:#5555DD;text-decoration:underline; }
	.ctl00_ContentPlaceHolder1_PermissionUserControl2_TreeView1_8 { color:#5555DD;text-decoration:underline; }
 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset>
        <legend>新增角色</legend>
        <div><label>
            角色名稱</label>&nbsp;<asp:TextBox ID="roleName" runat="server" Width="250px"></asp:TextBox>  </div>
          <div><label>
            角色描述</label>&nbsp;<asp:TextBox ID="description" runat="server" Width="250px"></asp:TextBox>  </div>
           
    </fieldset>
    <fieldset>
        <legend >選取角色權限</legend>
        <uc1:PermissionUserControl ID="PermissionUserControl2" runat="server" permissionString="" />
    </fieldset>
    <div class="bottom_btn" style="text-align:center">
        <asp:Button ID="btnUpdate" runat="server" Text="確定" CssClass="button" 
            onclick="btnUpdate_Click" />
        <asp:Button ID="btnList" runat="server" Text="回上頁" CssClass="button" 
            onclick="btnList_Click" />
    </div>
</asp:Content>

