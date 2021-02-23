<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginService.Views.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1> <br />
            <h2>Bitte geben sie ihre Logindaten an!</h2> <br />
            <h3>Anmeldename: </h3> <asp:TextBox ID="txtUID" runat="server" Width="150" Height="20"></asp:TextBox> <br />
            <h3>Passwort: </h3> <asp:TextBox ID="txtPW" runat="server" Width="150" Height="20" TextMode="Password"></asp:TextBox> <br /> <br />
            <asp:Button ID="btnOK" runat="server" Text="Anmelden" Width="150" Height="40" OnClick="btnOK_Click" /> <br />
            <asp:Label runat="server" ID="lblLoginInfo"></asp:Label> <br /> <br /> <br />
            <asp:Button runat="server" ID="btnCheckAuth" Text="Check Login" OnClick="CheckAuth_Click" />
        </div>
    </form>
</body>
</html>