<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="MemberNews_Detail.aspx.cs" Inherits="MemberNews_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/print.css" rel="stylesheet" type="text/css" media="print" />
    <script type="text/javascript" src="js/jquery.history.js"></script>
		<script type="text/javascript" src="js/jquery.galleriffic.js"></script>
		<script type="text/javascript" src="js/jquery.opacityrollover.js"></script>
		<!-- We only want the thunbnails to display when javascript is disabled -->
		<script type="text/javascript">
		    document.write('<style>.noscript { display: none; }</style>');
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="detail">
    <h1>團員分享</h1>
<div  class="news_word">
        <h2 >
         標　題：<asp:Label ID="title" runat="server" Text="Label"></asp:Label> <br />
        發表人：<asp:Label ID="poster" runat="server" ></asp:Label>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:Label ID="initDate" runat="server" ></asp:Label>
       
    </h2>
    <div style="border-bottom:1px dashed #017EB6;width:600px; margin:10px auto;"></div>

<asp:Label ID="article" runat="server"></asp:Label>


 <h2 id="h2file" runat="server">附件下載</h2>
<div>
    <asp:DataList ID="dlFile" runat="server" RepeatColumns="4" CssClass="page_text_file">
            <HeaderTemplate>
                
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink CssClass="range" ID="hlFile" Target="_blank" runat="server" Text='<%# Eval("fileName") %>'
                    NavigateUrl='<%# "~/UploadFiles/Files/" + Eval("fileUrl") %>'></asp:HyperLink></ItemTemplate>
            <FooterTemplate>
                
            </FooterTemplate>
        </asp:DataList>
</div>
    <div style="border-bottom:1px dashed #017EB6;width:600px; margin:10px auto;"></div>

<h2 id="h1" runat="server">回覆</h2>
<div class="bottom_btn" style="text-align:right;margin:0 15px 10px 0;">
<input value="團員回覆" type="button" class="jquery_click" id="btnOpenReply" runat="server"  />
</div>
<div class="jquery_open" style="display:none;">
  <div style="margin:0 0 0 40px;">
<asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Width="550" Height="200px"></asp:TextBox>
       </div>
  <div class="bottom_btn">
    <asp:Button ID="btnReply" runat="server" Text="回覆" OnClick="btnReply_Click" />
    <input value="回列表" type="button" onclick="javascript: history.back(1);" />
</div>
</div>
</div>




    <div style="margin:10px 0 0 0;">
        <asp:Repeater ID="repReply" runat="server">
            <HeaderTemplate>
            
            </HeaderTemplate>
            <ItemTemplate>
                <table class="faq">
                       <tr>
                            <th width="15%">
                                姓　　名
                            </th>
                          <td>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("articleTitle") %>'></asp:Label>
                              </td>
                          <th  width="15%">發表時間</th>
                          <td> <asp:Label ID="lblinitDate" runat="server" Text='<%# Eval("initDate","{0:yyyy/MM/dd}") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <th width="15%">
                                發表內容
                            </th>
                            <td colspan="3">
                               <asp:Label ID="Label2" runat="server" Text='<%# My.WebForm.TXT2HTML(Eval("article").ToString()) %>'></asp:Label>   </td>
                        </tr>
                      
                   </table>
                        
               
                        
                  
                   
              
            </ItemTemplate>
            <FooterTemplate>
          
            </FooterTemplate>
        </asp:Repeater>
       
          
       
         <asp:Label ID="lblMessage" runat="server" Text="你尚未登入!"></asp:Label>
       
</div>
</div>
</asp:Content>

