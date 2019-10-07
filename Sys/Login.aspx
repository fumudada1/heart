<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="manage_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>後台管理系統</title>
<link href="css_styles/login.css" rel="stylesheet" type="text/css" />
<link href="css_styles/common.css" rel="stylesheet" type="text/css" />
<link href="css_styles/components/jquery_validate.css" rel="stylesheet" type="text/css" />
<script src="javascript/jquery-1.5.2.min.js" type="text/javascript"></script>
<script src="javascript/jquery.validate.js" type="text/javascript"></script>
<script type="text/javascript">
           $(document).ready(function () {
               $("#form1").validate({
                   errorLabelContainer: $("#form1 div.container")
               });
           });
            
</script>
</head>
<body>


<form id="form1" runat="server">
<div class="wrap">
<div id="header"></div>
<!--主內容 開始 -->
<div class="center">




<div class="mgt_login">

<div class="mgt_writing1"> <asp:TextBox ID="Username" runat="server" CssClass="writing" ></asp:TextBox></div>
<div class="mgt_writing2"> <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="writing"></asp:TextBox></div>
<div class="mgt_writing3"> <asp:ImageButton ID="ibtnButton" CssClass="login_btn" runat="server" ImageUrl="images/mgt_login_btn.jpg"  onclick="ibtnButton_Click" />  </div>


<div class="ErrorInfo">
                        <asp:Label ID="lblErrer" runat="server"></asp:Label>
                    </div>


</div>


<div class="container"><h4>你送出的資料有錯誤，請檢視下列訊息</h4>
	    <ol>
		<li><label for="Username" class="error"> 請輸入帳號</label></li>
	   	<li><label for="Password" class="error"> 請輸入密碼</label></li>
	    </ol>
    </div>




</div>
<div class="clear"></div>
<div class="footer_bg"></div>
<div id="footer">
<div class="ft3"<p class="ft3_p"></p>
<p class="ft3_p">

</div>
</div>
                    
    </form>
    
                 
               
</body>
</html>
