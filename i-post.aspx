<%@ Page ValidateRequest="false"  Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="i-post.aspx.cs" Inherits="i_post" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <h1>團員專區</h1>
 <div class="member_btn">
<a class="member_btn_1" href="member_person.aspx" title="修改團員資料"></a>
<a class="member_btn_2"  href="donation_person.aspx" title="善款明細記錄"></a>
<a class="member_btn_4_1"  href="i-post.aspx" title="發表團員分享"></a>
<a class="member_btn_3"  href="i-donation.aspx" title="捐贈登錄"></a>

</div>
<div class="bottom_btn" style="text-align:right;" >
<input type="button" onclick="location.href='i-post_Insert.aspx'" value="新增團員分享" />
        <asp:HyperLink ID="lnkAddAdmin" runat="server" ></asp:HyperLink>
      </div>
    <div style="margin:-30px 0 0 0">
     關鍵字<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
      <asp:Button ID="btnSearch"
          runat="server" Text="搜尋" onclick="btnSearch_Click" />
      
      
      <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="重設" />
      
      
  </div>
   <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" Font-Size="14px" 
        onrowdatabound="gvList_RowDataBound" onrowdeleting="gvList_RowDeleting" 
        Width="100%" EnableModelValidation="True" 
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
              <asp:BoundField DataField="OrgNames" HeaderText="單位" 
                  SortExpression="OrgNames" Visible="False" >
			
              </asp:BoundField>
              <asp:BoundField DataField="className" HeaderText="類別名稱" 
                  SortExpression="className" Visible="False" />
              <asp:BoundField DataField="title" HeaderText="標題" SortExpression="title"  ItemStyle-CssClass="foo_left" >
              <ItemStyle HorizontalAlign="Left" CssClass="left" />
			
			  	 <HeaderStyle Width="50%" HorizontalAlign="Left" CssClass="left" />
              </asp:BoundField>
              <asp:BoundField DataField="poster" HeaderText="發佈者" SortExpression="poster" >
               <HeaderStyle Width="10%" />
                  </asp:BoundField>
              <asp:TemplateField HeaderText="顯示狀態" SortExpression="enable" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblEnable" runat="server" Text='<%# Eval("enable").ToString()=="True"?"顯示":"不顯示" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="張貼日" 
                  SortExpression="initDate" />
              <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="開始日" 
                  SortExpression="startDate" Visible="False" />
              <asp:TemplateField HeaderText="結束日" SortExpression="endDate" Visible="False">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("endDate", "{0:d}")=="2800/1/1"?"":Eval("endDate", "{0:d}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("endDate") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="counts" HeaderText="點閱數" SortExpression="counts" >
              <ItemStyle HorizontalAlign="Center" />
              </asp:BoundField>
             <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                        <asp:HiddenField ID="hidbeSelect" runat="server" 
                            Value='<%# Eval("beSelect") %>' />
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" 
                            CommandName="Update" ImageUrl="~/Sys/images/Modify.gif" />
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="~/Sys/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;" />
                    </ItemTemplate>
                    
             </asp:TemplateField>
          </Columns>
          
      </asp:GridView>
      <div class="cc_m_listguide">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
</asp:Content>

