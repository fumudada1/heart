<%@ Page Title="" Language="C#" MasterPageFile="~/Sys/MasterPage.master" AutoEventWireup="true" CodeFile="Input_list.aspx.cs" Inherits="Sys_Input_Input_list" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/ui.datepicker-zh-TW.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.core.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.datepicker.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/ui.theme.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker input").datepicker();

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
        <asp:HyperLink ID="lnkAddAdmin" runat="server" >新增收入資料</asp:HyperLink>
       <div style="clear:both"></div>
      </div>
  <div>
      核准：<asp:DropDownList ID="ddlEnable" runat="server">
          <asp:ListItem  Value="">全部</asp:ListItem>
          <asp:ListItem Value="False">否</asp:ListItem>
          <asp:ListItem Value="True">是</asp:ListItem>
      </asp:DropDownList>
      暱稱：<asp:DropDownList ID="ddlCustomer" runat="server">
                </asp:DropDownList>
     <span class="datepicker">
            匯款日期：<asp:TextBox ID="startDate" runat="server" Width="88px"></asp:TextBox>
            ~<asp:TextBox ID="endDate" runat="server" Width="88px"></asp:TextBox></span>
     
      <asp:Button ID="btnSearch"
          runat="server" Text="搜尋" onclick="btnSearch_Click" />
      
      
  </div>
   <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" Font-Size="14px" 
        onrowdatabound="gvList_RowDataBound" onrowdeleting="gvList_RowDeleting" 
        Width="90%" EnableModelValidation="True" 
        onrowupdating="gvList_RowUpdating" CssClass="tableStyle1" GridLines="None" AllowSorting="True" OnSorting="gvList_Sorting">
          <Columns>
            <asp:CheckBoxField DataField="enable" HeaderText="核准" 
                SortExpression="enable" />
              <asp:BoundField DataField="aliasName" HeaderText="暱稱" 
                  SortExpression="aliasName" />
            <asp:BoundField DataField="payDate" HeaderText="匯款時間" SortExpression="payDate" 
                  DataFormatString="{0:d}" />
            <asp:BoundField DataField="coco" HeaderText="金額" DataFormatString="{0:C0}" />
            <asp:BoundField HeaderText="匯款帳號後五碼" />
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [InputData]" 
            DeleteCommand="DELETE FROM [InputData] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [InputData] ([customerID], [aliasName], [coco], [bankNumber], [payDate], [enable], [initDate], [poster]) VALUES (@customerID, @aliasName, @coco, @bankNumber, @payDate, @enable, @initDate, @poster)" 
            UpdateCommand="UPDATE [InputData] SET [customerID] = @customerID, [aliasName] = @aliasName, [coco] = @coco, [bankNumber] = @bankNumber, [payDate] = @payDate, [enable] = @enable, [initDate] = @initDate, [poster] = @poster WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="customerID" Type="Int32" />
                <asp:Parameter Name="aliasName" Type="String" />
                <asp:Parameter Name="coco" Type="Decimal" />
                <asp:Parameter Name="bankNumber" Type="String" />
                <asp:Parameter Name="payDate" Type="DateTime" />
                <asp:Parameter Name="enable" Type="Boolean" />
                <asp:Parameter Name="initDate" Type="DateTime" />
                <asp:Parameter Name="poster" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="customerID" Type="Int32" />
                <asp:Parameter Name="aliasName" Type="String" />
                <asp:Parameter Name="coco" Type="Decimal" />
                <asp:Parameter Name="bankNumber" Type="String" />
                <asp:Parameter Name="payDate" Type="DateTime" />
                <asp:Parameter Name="enable" Type="Boolean" />
                <asp:Parameter Name="initDate" Type="DateTime" />
                <asp:Parameter Name="poster" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

      <div style="display:inherit">
    </div>
      <div class="cc_m_listguide">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
</asp:Content>

