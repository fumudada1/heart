<%@ Page Title="單位管理" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Unit_list.aspx.cs" Inherits="Sys_Unit_Unit_list" %>

<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/thickbox.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/thickbox.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".selectall input").click(function () {
                $(".selectOne input").each(function () {
                    $(this).attr("checked", $(".selectall input").attr("checked"));
                });
            });

            $(".selectOne input").click(function () {
                $(".selectall input").attr("checked", false);
            });
        });

    </script>
    <style type="text/css">
        .tableStyle1 tr:hover td
        {
            background-color: #B8E4E4;
        }
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
      <input onclick="location='Unit_Insert.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button" value="新增單位" class="Addbutton" />
       <div style="clear:both"></div>
      </div>
  
   <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" Font-Size="14px" 
        Width="90%" EnableModelValidation="True" 
        onrowupdating="gvList_RowUpdating" CssClass="tableStyle1" GridLines="None">
          <Columns>
          <asp:TemplateField Visible="False">
                <HeaderTemplate>
                    <asp:CheckBox ID="CheckBox2" CssClass="selectall" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="selectOne" />
                </ItemTemplate>
                
            </asp:TemplateField>
              <asp:BoundField DataField="title" HeaderText="單位" SortExpression="title" >
              
              </asp:BoundField>
              <asp:BoundField DataField="poster" HeaderText="發佈者" SortExpression="poster" Visible="False"/>
              
              <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="建立日期" 
                  SortExpression="initDate" />
             

             <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" 
                            CommandName="Update" ImageUrl="../images/Modify.gif" />
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="../images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;" />
                    </ItemTemplate>
                    
             </asp:TemplateField>
          </Columns>
          
      </asp:GridView>
      <div style="display:inherit">
        <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;"
            Visible="False" />
    </div>
      <div class="cc_m_listguide">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
</asp:Content>


