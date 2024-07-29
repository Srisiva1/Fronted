<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewUserDownloadFileDetails.aspx.cs" Inherits="AdminViewUserDownloadFileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%" style ="color:Black ;">
<tr>
<th><h3>View Download Files</h3></th>
</tr>
<tr>
<td style ="text-align :center ;">
<center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
        ForeColor="Black">
    <Columns>
    <asp:BoundField DataField ="duserid" HeaderText ="User Id" />
        <asp:BoundField DataField ="fownerid" HeaderText ="Owner Id" />
    <asp:BoundField DataField ="fileid" HeaderText ="File Id" />
    <asp:BoundField DataField ="filename" HeaderText ="File Name" />
    <asp:BoundField DataField ="ddate" HeaderText ="Download Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
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
<td style ="text-align :center ;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>
</tr>

</table>
</asp:Content>

