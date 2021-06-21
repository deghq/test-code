<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Password {
            width: 186px;
            height: 32px;
            margin-left: 21px;
        }
        #EmailAddress {
            height: 29px;
            width: 187px;
        }
        #form1 {
            height: 193px;
        }
    </style>
    <script src="//jquery.com/jquery-wp-content/themes/jquery/js/modernizr.custom.2.8.3.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.11.3.js"></script>
	<script src="//jquery.com/jquery-wp-content/themes/jquery/js/plugins.js"></script>
	<script src="//jquery.com/jquery-wp-content/themes/jquery/js/main.js"></script>

</head>
<body style="width: 340px; height: 201px; margin-left: 846px; margin-right: 294px; margin-top: 294px">
    <form id="form1" runat="server">
        <div>
                <!-- TODO: Create login components here! -->
              
                Login Account</div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="EmailAddress :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmalAddress" runat="server" Height="25px" Width="183px" TextMode ="Email"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" Height="25px" style="margin-left: 41px" Width="152px" TextMode ="Password"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:LinkButton ID="linklblRegistration" runat="server" OnClick="linklblRegistration_Click">Register Account?</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="107px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
  
    
    
</body>
</html>
