<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true"
    CodeFile="News_List.aspx.cs" Inherits="News_List" %>

<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="news_title">
    </div>
    <div class="search" style="display: none;">
        <div id="pageSearch">
            <span>
                <asp:TextBox ID="txtSearch" runat="server" class="input"></asp:TextBox>
            </span><span></span><span>
                <asp:Button ID="SureBtn" runat="server" Text="�T�w" OnClick="SureBtn_Click1" />
            </span><span>
                <asp:Button ID="btnReset" runat="server" Text="���s�]�w" OnClick="btnReset_Click" />
            </span>
        </div>
    </div>

    
    <h1>���ʮ���</h1>
<div class="news_list">
<!--�����j�� �}�l -->
 
    <asp:Repeater ID="Repeater1" runat="server">
       
        <ItemTemplate>
            <div class="news">
<div class="news_left">
<asp:Image ID="Image1" ImageUrl='<%# Eval("picUrl").ToString()==""?"images/news_bg.png":"~/UploadFiles/Images/s" + Eval("picUrl") %>' runat="server" />
 </div>
<div class="news_right">
<p class="news_right_title">
<asp:HyperLink ID="hlAbout" runat="server" Text='<%# My.WebForm.limitWord(Eval("title"),20)  %>'
                        NavigateUrl='<%# "News_Detail.aspx?id="+Eval("id") %>'> </asp:HyperLink></p>
    <p class="news_right_date">
        <asp:Label ID="lblinitDate" runat="server" Text='<%# Eval("initDate","{0:yyyy/MM/dd}") %>'></asp:Label>�i<asp:Label ID="Label1" runat="server" Text='<%# Eval("poster") %>'></asp:Label>�j
    </p>
<p class="news_right_content">
    <asp:Literal ID="article" runat="server" Text='<%# Eval("shortDescription") %>' ></asp:Literal>
<asp:HyperLink ID="HyperLink1" runat="server" Text="(�ԲӾ\Ū)"
                        NavigateUrl='<%# "News_Detail.aspx?id="+Eval("id") %>'> </asp:HyperLink>
</p>
</div>
 <div class="clear">
</div>
</div>

        </ItemTemplate>
       
    </asp:Repeater>
    <div class="paging">
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>
<!--�����j�鵲�� -->
</div>

<!--���X��m�B �}�l -->

<!--���X��m�B ���� -->
</asp:Content>
