<%@ Page Title="" Language="C#" MasterPageFile="~/Heart.master" AutoEventWireup="true" CodeFile="record1_Detail.aspx.cs" Inherits="record1_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="detail">
    <h1>雲施紀錄(支出)</h1>
<div  class="news_word">
        <h2>
         標　題：<asp:Label ID="subject" runat="server" Text="Label"></asp:Label> <br />
        發表人：<asp:Label ID="poster" runat="server" ></asp:Label>&nbsp;&nbsp;|&nbsp;&nbsp;活動日期：<asp:Label ID="activityDate" runat="server" ></asp:Label>&nbsp;&nbsp;|&nbsp;&nbsp;
        金額:<asp:Label ID="coco" runat="server" Text="Label"></asp:Label>
       
    </h2>
    <div style="border-bottom:1px dashed #017EB6;width:600px; margin:10px auto;"></div>
<asp:Label ID="article" runat="server"></asp:Label>


</div>




    
</div>
</asp:Content>

