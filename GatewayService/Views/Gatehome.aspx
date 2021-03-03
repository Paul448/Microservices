<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gatehome.aspx.cs" Inherits="GatewayService.Views.Gatehome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>   
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/> <br />
            <asp:Button ID="btnAdmin" runat="server" Text="Admin-Panel (OLD)" OnClick="btnAdmin_Click"/> <br />
            <asp:Button ID="btnPS" runat="server" Text="User/Personenverwaltung" OnClick="btnPS_Click"/> <br />
            <asp:Button ID="btnTurnier" runat="server" Text="Turnierverwaltung" OnClick="btnTurnier_Click"/> <br />
            <asp:Button ID="btnMannschaft" runat="server" Text="Mannschaftsverwaltung" OnClick="btnMannschaft_Click"/> <br />
            <asp:Label ID="lblAuth" runat="server" Text="Auth: Error"></asp:Label> 
        </div>
    </form>
</body>
</html>
