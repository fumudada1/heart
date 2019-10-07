<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Culture_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<link rel="shortcut icon" href="favicon.ico">

<head runat="server">
    <title>雲施團</title>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/pagecode.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">

<div class="header">
<div class="logo" style="top:10px">
<a href="index.aspx" title="雲施團"></a>
</div>
<div style="position:absolute; top:105px;left:5px;box-shadow:2px 2px 2px rgba(20%,20%,40%,0.6),4px 4px 6px rgba(20%,20%,40%,0.4),6px 6px 12px rgba(20%,20%,40%,0.4);">
<iframe width="250" height="255" src="http://www.youtube.com/embed/G4ldEw-qjxU?rel=0" frameborder="0" allowfullscreen></iframe>

</div>
<div class="index_menu">
<ul>
<li class="index_menu_1"><a href="about.aspx" title="緣起"></a></li>
<li class="index_menu_2"><a  href="News_List.aspx" title="活動消息"></a></li>
<li class="index_menu_3"><a href="MemberNews_List.aspx" title="團員分享"></a></li>
<li class="index_menu_4"><a  href="record.aspx"  title="雲施記錄"></a></li>
<li class="index_menu_5"><a  href="member_person.aspx"  title="團員專區"></a>
</li>
</ul>
</div>
</div>
<div class="index_content">
<!--活動開始 -->
<div class="index_news">
<h1><img src="images/news_bg.jpg" width="356" height="20" /></h1>
     <asp:Repeater ID="repNews" runat="server">
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
  <p class="index_news_time"><asp:Label ID="lblinitDate" runat="server" Text='<%# Eval("initDate","{0:yyyy/MM/dd}") %>'></asp:Label>【<asp:Label ID="Label1" runat="server" Text='<%# Eval("poster") %>'></asp:Label>】</p>
<p class="index_news_content">
    <asp:HyperLink ID="hlAbout" runat="server" Text='<%# My.WebForm.limitWord(Eval("title"),20)  %>'
                        NavigateUrl='<%# "News_Detail.aspx?id="+Eval("id") %>'> </asp:HyperLink>
</p>
</li>
                                    
                                    </ItemTemplate>
                                    <FooterTemplate>                                      
</ul>
                                    </FooterTemplate>
                                </asp:Repeater>



<a href="News_List.aspx" class="index_news_more"></a>
</div>
<!--活動結束 -->
<!--團員開始 -->
<div class="index_member">
<h1><img src="images/member_bg.jpg"  /></h1>
     <asp:Repeater ID="repMemberNews" runat="server">
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
  <p class="index_news_time"><asp:Label ID="lblinitDate" runat="server" Text='<%# Eval("initDate","{0:yyyy/MM/dd}") %>'></asp:Label>【<asp:Label ID="Label2" runat="server" Text='<%# Eval("poster") %>'></asp:Label>】</p>
<p class="index_news_content">
    <asp:HyperLink ID="hlAbout" runat="server" Text='<%# My.WebForm.limitWord(Eval("title"),20)  %>'
                        NavigateUrl='<%# "MemberNews_Detail.aspx?id="+Eval("id") %>'> </asp:HyperLink>
</p>
</li>
                                    
                                    </ItemTemplate>
                                    <FooterTemplate>                                      
</ul>
                                    </FooterTemplate>
                                </asp:Repeater>
<ul>

</ul>
<a href="MemberNews_List.aspx" class="index_member_more"></a>
</div>
<!--團員結束 -->

</div>
<!--右側區塊 開始 -->
<div class="sidebar">
<div class="nav">
                <a href="index.aspx">回首頁</a>
            </div>
            <div class="login">
<!--登入前 開始 -->
<div  id="divBefor" runat="server">
<h2><img src="images/member_no.png" width="81" height="44" /></h2>
<div class="index_login_word">
 <p>帳號：</p>
<p>密碼：</p>
                            </div>
     <asp:TextBox ID="account" runat="server" CssClass="login_text login_accont" ToolTip="請輸入帳號"></asp:TextBox>
                            <asp:TextBox ID="password" TextMode="Password" CssClass="login_text login_password" ToolTip="請輸入密碼"
                                runat="server"></asp:TextBox>
<div class="login_text">
<p><br />
  <a href="add_member.aspx">加入團員</a></p>
  </div>
  
     <asp:Button ID="Button1" runat="server" CssClass="login_btn" ToolTip="輸入" OnClick="Button1_Click" />
  </div>

<!--登入前 結束 -->
<!--登入後 開始 --><div id="divAfter" runat="server">
<h2><img src="images/member_yes.png" width="81" height="44" /></h2>
<p>hi,<asp:Literal ID="userName" runat="server"></asp:Literal></p>
<ul>
<li><a href="member_person.aspx">‧修改個人資料</a></li>
<li><a href="donation_person.aspx">‧善款明細記錄</a></li>
<li><a href="i-donation.aspx">‧我要捐贈</a></li>
<li><a href="i-post.aspx">‧發表團員分享</a></li>
</ul>
     <asp:Button ID="btn_logout" runat="server" OnClick="btn_logout_Click" CssClass="logout_btn" ToolTip="登出雲施團" />
</div>
<!--登入後 結束 -->
</div>
<div class="side_block">
<a href="donation.aspx"><img src="images/side_banner1.jpg" /></a>
<a href="http://www.myerstone.com.tw" target="_blank"><img  src="images/myerstone.jpg" /></a>

<a href="http://www.nonahz.org/" target="_blank"><img src="images/banner_3.jpg" alt="" /></a>
<a href="http://www.nmmba.gov.tw" target="_blank"><img src="images/AQUARIUM.jpg" /></a>
<a target="_blank" href="sys/login.aspx"><img src="images/mod.jpg" /></a>
</div>
</div>
<div class="clear"></div>
<!--右側區塊 結束 -->
<div class="footer">
聯絡我們：<a href="mailto:myerstone@gmail.com">myerstone@gmail.com</a>
</div>
</div>

    </form>
</body>
</html>
