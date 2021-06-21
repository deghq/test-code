<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 287px;
            width: 377px;
        }
    </style>
</head>
<body style="margin-left: 849px; margin-top: 326px">
    <form id="form1" runat="server">
        <div>
            <!-- TODO: Create sign up components here -->
        </div>
        <p>
            Account Registration</p>
        <p>
            <asp:Label ID="lblEmailAddress" runat="server" Text="EmailAddress :"></asp:Label>
            <asp:TextBox ID="txtEmailAddress" runat="server" style="margin-left: 25px" Height="27px" Width="201px" TextMode="Email"></asp:TextBox>
        </p>
        <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" style="margin-left: 50px" Height="29px" OnTextChanged="txtPassword_TextChanged" Width="196px" TextMode ="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Phone :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPhone" runat="server" Height="28px" Width="198px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnsave" runat="server" Height="33px" OnClick="Button1_Click" style="margin-top: 0px" Text="SAVE" Width="124px" />
    </form>
</body>
</html>
