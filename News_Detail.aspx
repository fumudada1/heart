<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="News_Detail" %>

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
    <h1>���ʮ���</h1>
<div  class="news_word">
        <h2>
         �С@�D�G<asp:Label ID="title" runat="server" Text="Label"></asp:Label> <br />
        �o��H�G<asp:Label ID="poster" runat="server" ></asp:Label>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:Label ID="initDate" runat="server" ></asp:Label>
       
    </h2>
    <div style="border-bottom:1px dashed #017EB6;width:600px; margin:10px auto;"></div>
<asp:Label ID="article" runat="server"></asp:Label>


 <h2 id="h2file" runat="server">����U��</h2>
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
<h2 id="h1" runat="server">�^��</h2>
<div class="bottom_btn" style="text-align:right;margin:0 15px 10px 0;">
 <input value="�έ��^��" type="button" class="jquery_click" id="btnOpenReply" runat="server"  />
</div>
<div class="jquery_open" style="display:none;">
  <div style="margin:0 0 0 40px;">
<asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Width="550" Height="200px"></asp:TextBox>
       </div>
  <div class="bottom_btn">
    <asp:Button ID="btnReply" runat="server" Text="�^��" OnClick="btnReply_Click" />
    <input value="�^�C��" type="button" onclick="javascript: history.back(1);" />
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
                                �m�@�@�W
                            </th>
                          <td>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("articleTitle") %>'></asp:Label>
                              </td>
                          <th  width="15%">�o��ɶ�</th>
                          <td> <asp:Label ID="lblinitDate" runat="server" Text='<%# Eval("initDate","{0:yyyy/MM/dd}") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <th width="15%">
                                �o���e
                            </th>
                            <td colspan="3">
                               <asp:Label ID="Label2" runat="server" Text='<%# My.WebForm.TXT2HTML(Eval("article").ToString()) %>'></asp:Label>   </td>
                        </tr>
                      
                   </table>
                        
               
                        
                  
                   
              
            </ItemTemplate>
            <FooterTemplate>
          
            </FooterTemplate>
        </asp:Repeater>
       
          
       
         <asp:Label ID="lblMessage" runat="server" Text="�A�|���n�J!"></asp:Label>
       
</div>
</div>
</asp:Content>

