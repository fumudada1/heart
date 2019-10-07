<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PermissionUserControl.ascx.cs" Inherits="UserControl_PermissionUserControl" %>
<span style="display:none">
<asp:Button ID="btnOpen" runat="server" Text="全部開啟" onclick="btnOpen_Click" />
<asp:Button ID="btnClose" runat="server"
    Text="全部折疊" onclick="btnClose_Click1" /></span>
<asp:XmlDataSource id="XmlDataSource1" runat="server" XPath="/menu/Modules" 
        DataFile="~/Sys/Menu.xml"></asp:XmlDataSource>
        <p>
            <input id="Hidden1" type="hidden" />
</p>
        <asp:TreeView ID="TreeView1" runat="server" 
        ImageSet="Arrows" ondatabound="TreeView1_DataBound" ExpandDepth="0" >
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" />
            <DataBindings>
                <asp:TreeNodeBinding DataMember="Modules" ShowCheckBox="True" TextField="Title" 
                    ToolTipField="Title" ValueField="value" />
            </DataBindings>
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
    </asp:TreeView>