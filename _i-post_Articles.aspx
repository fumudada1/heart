<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="_i-post_Articles.aspx.cs" Inherits="_i_post_Articles" %>

<%@ Register Src="UserControl/PublishTab.ascx" TagName="PublishTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.7.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/webEditor/ckeditor/ckeditor.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <h1>團員專區</h1>
 <div class="member_btn">
<a class="member_btn_1" href="member_person.aspx" title="修改團員資料"></a>
<a class="member_btn_2"  href="donation_person.aspx" title="善款明細記錄"></a>
<a class="member_btn_4_1"  href="i-post.aspx" title="發表團員分享"></a>
<a class="member_btn_3"  href="i-donation.aspx" title="捐贈登錄"></a>

</div>
<div class="clear"></div> 
    <uc2:PublishTab ID="PublishTab1" runat="server" tab="5" FunctionName="i-post" isCloseImageTab="True"  isCloseLinkTab="True" />
    <div class="clear"></div> 
    <fieldset> 
        <legend>回覆管理</legend>
        <div>
      <div style="margin:10px 0 0 0;">
        <asp:Repeater ID="repReply" runat="server" OnItemCommand="repReply_ItemCommand">
            <HeaderTemplate>
            
            </HeaderTemplate>
            <ItemTemplate>
                <table class="faq" style="border-width: 1px;border-style: dashed">
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
                    <tr>
                        <td colspan="4"> <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="~/Sys/images/color_1_41.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) return false;" />
                            <asp:HiddenField ID="hidID" runat="server" Value='<%# Eval("id") %>' />
                        </td>
                    </tr>
                      
                   </table>
                        
               
                        
                  
                   
              
            </ItemTemplate>
            <FooterTemplate>
          
            </FooterTemplate>
        </asp:Repeater>
       
          
       
</div>
        </div>
        <div class="bottom_btn">
           
            <input onclick="location='i-post.aspx?ModuleID=N02&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>    '" type="button" value="回列表" class="button" />
    </div>
    </fieldset>
    </asp:Content>

