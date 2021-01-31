<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="LoginService.Views.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin Controll</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>DB USERS:</h1> <br />
            <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label> <br />
            <asp:Table ID="TUSERS" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableCell>UID:</asp:TableCell>
                    <asp:TableCell>NAME:</asp:TableCell>
                    <asp:TableCell>PASSWORT:</asp:TableCell>
                    <asp:TableCell>STATUS:</asp:TableCell>
                    <asp:TableCell>INFO:</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
