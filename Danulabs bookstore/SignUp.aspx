<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Danulabs_bookstore.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Styles/SignUpAddEditBook.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="p-header">*Mandatory field</p>
    <div id="table-body">
        <h2>Sign up</h2>
        <table>
            <tr>
                <td id="column1">Username*</td>
                <td>
                    <asp:TextBox ID="tbusername" runat="server" /></td>
                <td>
                    <asp:Label ID="lblusername" runat="server" /></td>
            </tr>
            <tr>
                <td>Password*</td>
                <td>
                    <asp:TextBox ID="tbpassword" TextMode="Password" runat="server" /></td>
                <td>
                    <asp:Label ID="lblpassword" runat="server" /></td>
            </tr>
            <tr>
                <td>Repeat password*</td>
                <td>
                    <asp:TextBox ID="tbrepeatpassword" TextMode="Password" runat="server" /></td>
                <td>
                    <asp:Label ID="lblrepeatpassword" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnconfirm" runat="server" Text="Confirm" OnClick="btnconfirm_Click" />
                    <a href="Home.aspx">cancel</a>
                </td>
                <td></td>
            </tr>
        </table>
        <asp:Label ID="lblerror" runat="server" />        
    </div>

 <script type="text/javascript">

     $(document).ready(function() {

             $("#form1").validate(
                 {                     
                     onfocusout: function (element) {
                         $(element).valid(),
                         $("#lblusername").hide(),
                         $("#lblpassword").hide(),
                         $("#lblrepeatpassword").hide()
                     },
                     focusCleanup: true,                     

                     rules:
                         {
              

                             "<%=tbusername.UniqueID %>":
                                    {
                                        required: true
                                    },
                             "<%=tbpassword.UniqueID %>":
                                 {
                                     required: true
                                 },
                             "<%=tbrepeatpassword.UniqueID %>":
                                 {
                                     required: true,
                                     equalTo: "#tbpassword"
                                 }
                         },
                     messages:
                         {
                             "<%=tbusername.UniqueID %>":
                                 {                                     
                                     required: "this field is mandatory!"
                                 },
                             "<%=tbpassword.UniqueID %>":
                                 {
                                     required: "this field is mandatory!"
                                 },
                             "<%=tbrepeatpassword.UniqueID %>":
                                 {
                                     required: "this field is mandatory!",
                                     equalTo: "passwords don't match!"

                                 }
                         }


                 });
         }
     );

    </script>

</asp:Content>
