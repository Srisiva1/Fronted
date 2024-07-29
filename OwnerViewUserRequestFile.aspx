<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OwnerViewUserRequestFile.aspx.cs" Inherits="OwnerViewUserRequestFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%" style ="color:Black ;">
<tr>
<th colspan ="2"><h3>View Requested File Details</h3></th>
</tr>
<tr>
<td style ="text-align :right ;">Owner Id</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
</td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
<center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="frid" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
    <Columns>
    <asp:BoundField DataField ="fid" HeaderText ="File Id" />
    <asp:BoundField DataField ="fname" HeaderText ="File Namee" />
    <asp:BoundField DataField ="ruserid" HeaderText ="Requested User Id" />
    <asp:BoundField DataField ="rdate" HeaderText ="Request Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
    <asp:ButtonField Text ="Accept" HeaderText ="Status" CommandName ="ac"    ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Red"/>
    <asp:ButtonField Text ="Reject"  CommandName ="re"    ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Red"/>
    </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
</center>
</td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>
</tr>
</table>
</asp:Content>

