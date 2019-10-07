<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Output_list.aspx.cs" Inherits="Sys_Output_Output_list" %>

<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
        .tableStyle1 tr:hover td
        {
            background-color: #B8E4E4;
        }
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="top_control">
        <asp:HyperLink ID="lnkAddAdmin" runat="server" >新增支出資料</asp:HyperLink>
       <div style="clear:both"></div>
      </div>
  <div style="display: none">
      關鍵字<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
      <asp:Button ID="btnSearch"
          runat="server" Text="搜尋" onclick="btnSearch_Click" />
      
      
      <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="重設" />
      
      
  </div>
       
   <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" Font-Size="14px" 
        onrowdatabound="gvList_RowDataBound" onrowdeleting="gvList_RowDeleting" 
        Width="90%" EnableModelValidation="True" 
        onrowupdating="gvList_RowUpdating" CssClass="tableStyle1" GridLines="None">
          <Columns>
           
                <asp:BoundField DataField="subject" HeaderText="活動名稱" 
                    SortExpression="subject" />
              
                <asp:BoundField DataField="coco" HeaderText="金額" SortExpression="coco" 
                    DataFormatString="{0:C0}" />
                <asp:BoundField DataField="activityDate" HeaderText="活動日期" 
                    SortExpression="activityDate" DataFormatString="{0:d}" />
               
             <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                      
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" 
                            CommandName="Update" ImageUrl="../images/Modify.gif" />
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="../images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;" />
                    </ItemTemplate>
                    
             </asp:TemplateField>
          </Columns>
          
      </asp:GridView>

      <div style="display:inherit">
    </div>
      <div class="cc_m_listguide">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
    <div>
        善款總金額：<asp:Label ID="lblInput" runat="server" Text="0"></asp:Label> 總支出：<asp:Label ID="lblOutput" runat="server" Text="0"></asp:Label>
    </div>
    <div>
        結餘：<asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>

