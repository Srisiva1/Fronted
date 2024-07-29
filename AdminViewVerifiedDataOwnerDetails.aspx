<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewVerifiedDataOwnerDetails.aspx.cs" Inherits="AdminViewVerifiedDataOwnerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%" style ="color:Black ;">
<tr>
<th><h3>Data Owner Details</h3></th>
</tr>

<tr>
<td style ="text-align :center ;">
   <center>
   
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" 
           BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
           CellSpacing="2" ForeColor="Black" >
    <Columns>
    <asp:BoundField DataField ="name" HeaderText ="Name" />
    <asp:BoundField DataField ="gender" HeaderText ="Gender" />
    <asp:BoundField DataField ="age" HeaderText ="Age" />
    <asp:BoundField DataField ="address" HeaderText ="Address" />
    <asp:BoundField DataField ="emailid" HeaderText ="Email Id" />
    <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
    <asp:BoundField DataField ="userid" HeaderText ="User Id" />
    <asp:BoundField DataField ="rdate" HeaderText ="Registration Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
    <asp:BoundField DataField ="status" HeaderText ="Status" />

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

   </center></td>

</tr>
<tr>
<td style ="text-align :center ;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>

</tr>

</table>

</asp:Content>

