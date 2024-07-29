<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OwnerFileUploading.aspx.cs" Inherits="OwnerFileUploading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%" style ="color:Black ;">
<tr>
<th colspan ="2"><h3>File Uploading</h3></th>
</tr>
<tr>
<td style ="text-align :right ;">Owner Id</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Owner Private Key</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

      &nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton4" runat="server"
        Font-Bold="True" onclick="LinkButton4_Click">Get Key</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Verify</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">File Id</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Select Upload File </td>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    </td>
</tr>
<tr>
<td style ="text-align :right ;">File Upload Date</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
        Font-Bold="True">Upload</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
        Font-Bold="True">Clear</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

