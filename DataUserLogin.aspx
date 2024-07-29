<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="DataUserLogin.aspx.cs" Inherits="DataUserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" width ="70%" align ="center" style ="color :Black ;" >
        <tr>
            <th colspan ="2">
                <h3 style =" text-align :center  ;">
                    User Login</h3>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                User Id</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                Width="100px" Font-Bold="True" Font-Size="Small">Login</asp:LinkButton>
                <span  style ="float :right ;">
                <asp:HyperLink ID="HyperLink1" runat="server"   Width="150px" 
                    NavigateUrl="~/DataUserRegistration.aspx" Font-Bold="True" 
                    Font-Size="Small">Registration</asp:HyperLink>
                </span>&nbsp;&nbsp;&nbsp;
           
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

