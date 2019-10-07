<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="News_List.aspx.cs" Inherits="manage_News_News_List" %>

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
    <div class="top_control">
        <asp:HyperLink ID="lnkAddAdmin" runat="server" >新增訊息</asp:HyperLink>
        <asp:HyperLink ID="lnkAddAdmin2" runat="server" Visible="False" >類別維護</asp:HyperLink>
        <a style="visibility:hidden"></a>
       <div style="clear:both"></div>
      </div>
  <div>
  <span style="display:none">發佈分類：<asp:DropDownList ID="ddlClass1" runat="server" 
         DataTextField="className" DataValueField="id">
    </asp:DropDownList>
       請選擇機關: <asp:DropDownList ID="ddlOrg" runat="server" DataTextField="title" DataValueField="id" >
    </asp:DropDownList>

  </span>
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
              <ItemStyle HorizontalAlign="Left" />
			
			  
              </asp:BoundField>
              <asp:BoundField DataField="poster" HeaderText="發佈者" SortExpression="poster" />
              <asp:TemplateField HeaderText="顯示狀態" SortExpression="enable" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblEnable" runat="server" Text='<%# Eval("enable").ToString()=="True"?"顯示":"不顯示" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="張貼日" 
                  SortExpression="initDate" />
              <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="開始日" 
                  SortExpression="startDate" />
              <asp:TemplateField HeaderText="結束日" SortExpression="endDate">
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
        <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;"
            OnClick="btnDelete_Click" Visible="False" />
    </div>
      <div class="cc_m_listguide">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
</asp:Content>

