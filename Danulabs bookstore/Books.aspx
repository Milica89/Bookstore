<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Danulabs_bookstore.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Books.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body-books">
        <h2>Books</h2>
        <asp:SqlDataSource ID="sourceBooks" runat="server"
            ConnectionString="<%$connectionStrings:DanulabsBookstore%>"
            SelectCommand="SELECT t.bookid, t.isbn, t.title, t.author, t.genre FROM book t WHERE NOT t.isdeleted"
            UpdateCommand="UPDATE book SET isbn=@isbn, title=@title, author=@author, genre=@genre WHERE bookid=@bookid"
            ProviderName="System.Data.SQLite" />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceBooks" AutoGenerateColumns="False" HeaderStyle-CssClass="Books.css" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" ShowHeader="false" PageSize="5">
            <Columns>
                <asp:BoundField DataField="ISBN" SortExpression="ISBN" />
                <asp:BoundField DataField="title" SortExpression="Title" />
                <asp:BoundField DataField="author" SortExpression="Author" />
                <asp:BoundField DataField="genre" SortExpression="Genre" />
                <asp:CommandField ShowSelectButton="true" ButtonType="Link" SelectText="edit" />
                <asp:CommandField ShowDeleteButton="true" ButtonType="Link" SelectText="delete" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_click" />
    </div>
</asp:Content>
