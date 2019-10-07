<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Role_Mapping.aspx.cs" Inherits="manage_A01Permission_Role_Mapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/thickbox.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.tablednd.0.5.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>" rel="stylesheet"
        type="text/css" />
        <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/thickbox.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="top_control">
         <a href="<%=String.Format("Role_AddAdmin.aspx?RoleID={0}&KeepThis=true&TB_iframe=true&height=400&width=600", Request["RoleID"]) %>" title="選擇成員" class="thickbox" >選擇成員</a>
        </div>
        <table width="100%">
        <tbody>
        <tr>
          <td>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                  CssClass="tableStyle1" EnableModelValidation="True" GridLines="None" 
                  DataKeyNames="id" onrowdeleting="GridView1_RowDeleting">
                  <Columns>
                      <asp:BoundField DataField="roleName" HeaderText="名稱名稱" 
                          SortExpression="roleName" />
                      <asp:BoundField DataField="account" HeaderText="帳號" SortExpression="account" />
                      <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                      <asp:BoundField DataField="Organization" HeaderText="單位" 
                          SortExpression="Organization" />
                      <asp:TemplateField HeaderText="刪除">
            <ItemTemplate>
            <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="~/Sys/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                  </Columns>
              </asp:GridView>
            </td></tr>
			<tr><td><asp:Button id="btnReturn" runat="server" Text="回上頁" 
                    onclick="btnReturn_Click" CssClass="Addbutton_bottom"></asp:Button></td></tr>
			</tbody></table>
</asp:Content>

