<%@ Page Language="C#" EnableEventValidation="true" AutoEventWireup="true" CodeFile="Role_AddAdmin.aspx.cs" Inherits="manage_A01Permission_Role_AddAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellSpacing="0" borderColorDark="#ffffff" cellPadding="0" width="624" borderColorLight="#99cc00"
				border="1">
				<tr>
					<td bgColor="#ccff99">
						<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR bgColor="#ffffff">
								<TD class="a12" style="HEIGHT: 17px" width="41%" bgColor="#99cc00" height="28">
									<table cellSpacing="0" cellPadding="0" width="224" border="0">
										<tr>
											<td width="18">&nbsp;</td>
											<td class="a15_w" width="206" height="24">請挑選管理者</td>
										</tr>
									</table>
								</TD>
								<TD style="HEIGHT: 17px" width="13%" bgColor="#ccff99">&nbsp;</TD>
								<TD class="a12" style="HEIGHT: 17px" width="46%" bgColor="#99cc00" height="28">
									<table cellSpacing="0" cellPadding="0" width="224" border="0">
										<tr>
											<td width="18">&nbsp;</td>
											<td class="a15_w" width="206" height="24">成員</td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR bgColor="#ffffff">
								<TD vAlign="top" align="left" bgColor="#e3ffc8">
									<div style="OVERFLOW: auto; HEIGHT: 240px">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            EnableModelValidation="True" BorderColor="#99CC00"
											BorderStyle="Solid" BorderWidth="1px" CellPadding="2" GridLines="Horizontal" CssClass="a15" Width="100%" 
                                            DataKeyNames="id" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" EnableViewState="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="單位">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrganization" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.Organization") %>'>
														</asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle ForeColor="#009933" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
														</asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle ForeColor="#009933" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        </div>
								</TD>
								<TD bgColor="#ccff99"><asp:button id="BtnRight" runat="server" Width="75" 
                                        Text="選擇-->>" onclick="BtnRight_Click"></asp:button><br />
                                                                                                <br />
									
								</TD>
								<TD vAlign="top" align="left" bgColor="#e3ffc8">
									<div style="OVERFLOW: auto; WIDTH: 267px; HEIGHT: 240px">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            EnableModelValidation="True" BorderColor="#99CC00"
											BorderStyle="Solid" BorderWidth="1px" CellPadding="2" GridLines="Horizontal" CssClass="a15" Width="100%" 
                                            DataKeyNames="id" onrowdeleting="GridView2_RowDeleting" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        
                                                            <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action"  CommandName="Delete" ImageUrl="~/Sys/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="單位">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrganization" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.Organization") %>'>
														</asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle ForeColor="#009933" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
														</asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle ForeColor="#009933" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        </div>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="608" border="0">
				<tr>
					<td>
						<div align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="136" align="center" border="0">
								<TR>
									<TD width="69" height="34">
										<div align="right"><asp:button id="BtnAdd2" runat="server" Text="確定" 
                                                onclick="BtnAdd2_Click"></asp:button></div>
										<div align="right"></div>
									</TD>
									<TD width="67">
										<div align="center"></div>
									</TD>
								</TR>
							</TABLE>
						</div>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
