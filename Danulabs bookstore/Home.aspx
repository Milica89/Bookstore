<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Danulabs_bookstore.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="Styles/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="p-body">
        Welcome to Danulabs bookstore!<br/><br/>Here you can browse our database, add new books, 
        edit or delete the old ones. Basically, you can do anything!<br/><br/>To browse the contents, 
        please sign in. or sign up for an account if you don't have one
    </p>

</asp:Content>
