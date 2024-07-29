<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style ="color :Black ;">
<h2>About Our Project</h2>
<p style ="text-align :justify ;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cloud computing has become an increasingly popular technological trend, as the performance of Cloud computing applications
can be greatly improved by delegating the cloud to manage massive  data. To protect the confidentiality of data outsourced
from  devices to the cloud, cryptographic mechanisms are
usually employed to encrypt the data in such a way that only the
user designated by the data owner can decrypt the data. 

</p>
    <p style ="text-align :justify ;">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; However,
in  multi-user environment, the encrypted data may also
need to be shared to more users beyond the initially designated
one. In this project, we propose a flexible privacy-preserving data
sharing (FPDS) scheme in cloud computing . With the FPDS
scheme,  user can encrypt data to a recipient by using
identity-based encryption. 

</p>
    <p style ="text-align :justify ;">
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; More importantly, the  user can
specify a fine-grained access policy to generate a delegation
credential, and then send this credential to the cloud so that
it can convert all the encrypted data satisfying the access policy
into new ciphertexts that are readable to a new recipient. In this
way,  users can share the data outsourced to the cloud in a
flexible and privacy-preserving manner. 

</p>
    <p style ="text-align :justify ;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Detailed security analysis
shows that the FPDS scheme is secure against semi-trusted cloud
and malicious  users. Thorough theoretical and experimental
analyses demonstrate the high efficiency of the scheme.

</p>
</div>
</asp:Content>

