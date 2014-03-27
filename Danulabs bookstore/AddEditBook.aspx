<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddEditBook.aspx.cs" Inherits="Danulabs_bookstore.AddEditBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/SignUpAddEditBook.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="p-header">*Mandatory field</p>
    <div id="main_div">
        <h2>
            <asp:Label ID="lbladdeditbook" runat="server" /></h2>
        <table>
            <tr>
                <td id="column1">ISBN*</td>
                <td>
                    <asp:TextBox ID="tbisbn" runat="server" /></td>
                <td>
                    <asp:Label ID="lblisbn" runat="server" /></td>
            </tr>
            <tr>
                <td>Title*</td>
                <td>
                    <asp:TextBox ID="tbtitle" runat="server" /></td>
                <td>
                    <asp:Label ID="lbltitle" runat="server" /></td>
            </tr>
            <tr>
                <td>Author*</td>
                <td>
                    <asp:TextBox ID="tbauthor" runat="server" /></td>
                <td>
                    <asp:Label ID="lblauthor" runat="server" /></td>
            </tr>
            <tr>
                <td>Genre*</td>
                <td>
                    <asp:TextBox ID="tbgenre" runat="server" /></td>
                <td>
                    <asp:Label ID="lblgenre" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                    <asp:LinkButton ID="lbcancel" runat="server" Text="cancel" OnClick="lbcancel_Click" />
                </td>
                <td></td>
            </tr>
        </table>
        <asp:Label ID="lblerror" runat="server" />
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#form1").validate(
                {

                    onfocusout: function (element) {
                        $(element).valid(),
                        $("#lblisbn").hide(),
                        $("#lbltitle").hide(),
                        $("#lblauthor").hide(),
                        $("#lblgenre").hide()
                    },
                    focusCleanup: true,
                    
                    rules:
                        {


                            "<%=tbisbn.UniqueID%>":
                                    {
                                        required: true,
                                        digits: true,
                                        rangelength: [13,13]
                                        
                                    },
                             "<%=tbtitle.UniqueID %>":
                                 {
                                     required: true
                                 },
                             "<%=tbauthor.UniqueID%>":
                                 {
                                     required: true                                     
                                 },
                            "<%=tbgenre.UniqueID%>":
                                {
                                    required:true
                                }
                         },
                     messages:
                         {
                             "<%=tbisbn.UniqueID%>":
                                 {
                                     required: "this field is mandatory!",
                                     digits: "ISBN must contain digits only!",
                                     rangelength: "ISBN must have exactly 13 digits!"
                                 },
                             "<%=tbtitle.UniqueID%>":
                                 {
                                     required: "this field is mandatory!"
                                 },
                             "<%=tbauthor.UniqueID%>":
                                 {
                                     required: "this field is mandatory!"                                     

                                 },
                             "<%=tbgenre.UniqueID%>":
                                 {
                                     required: "this field is mandatory!"
                                 }
                         }


                 });
     }
     );

    </script>

</asp:Content>
