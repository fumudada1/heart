<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="EmailTemplat_List.aspx.cs" Inherits="Sys_EmailTemplat_EmailTemplat_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
      <input onclick="location='EmailTemplat_Insert.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button" value="新增E-mail樣版" class="Addbutton" />
     
       <div style="clear:both"></div>
      &nbsp;<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" Font-Size="14px" GridLines="None" onrowdeleting="gvList_RowDeleting" 
        Width="100%" EnableModelValidation="True" CssClass="tableStyle1" 
            onrowupdating="gvList_RowUpdating">
          <Columns>
              <asp:BoundField DataField="number" HeaderText="代號" SortExpression="number" />
                      <asp:BoundField DataField="subject" HeaderText="標題" SortExpression="subject" />
                      <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="建立日期" 
                          SortExpression="initDate" />
             <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                         <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" 
                            CommandName="Update" ImageUrl="../images/Modify.gif" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="../images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>
          </Columns>
          
      </asp:GridView>
          <div>

              
              
                </div>
 </div>
    </asp:Content>

