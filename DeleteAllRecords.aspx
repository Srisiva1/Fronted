﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteAllRecords.aspx.cs" Inherits="DeleteAllRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True" Font-Size="Small">Delete All Records</asp:LinkButton>
<br />
<br />
<br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Homepage.aspx" 
        Font-Bold="True" Font-Size="Small">Back</asp:HyperLink>
<br />
<br />
    <br />
<br />
<asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Black"></asp:Label>
</asp:Content>

