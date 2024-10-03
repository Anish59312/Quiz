<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="QuizApp.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Admin Login</h2>
            <asp:Label ID="lblUserName" runat="server" Text="Login Username"></asp:Label>
            <br />
            <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Login Password"></asp:Label>
            <br />
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_click"/>
        </div>
    </form>
</body>
</html>
