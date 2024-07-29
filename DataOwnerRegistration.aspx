<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="DataOwnerRegistration.aspx.cs" Inherits="DataOwnerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center" width ="70%" style ="color :black ;">
<tr>
<th colspan ="2"><h3>Data Owner Registration</h3></th>
</tr>
<tr>
<td style ="text-align :right ;">Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Gender</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Date of Birth</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Age</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Address</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Email Id</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Mobile Number</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">User Id</td>
<td>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Password</td>
<td>
    <asp:TextBox ID="TextBox8" runat="server" TextMode="Password"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Registration Date</td>
<td>
    <asp:TextBox ID="TextBox9" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True" Font-Size="Small">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
        Font-Bold="True" Font-Size="Small">Clear</asp:LinkButton>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    </td>
</tr>

</table>
</asp:Content>

