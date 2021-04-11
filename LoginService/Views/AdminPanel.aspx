<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="LoginService.Views.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin Controll</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%; height:30px; background-color:grey; margin-top:0px; padding-top:0px;">
        <asp:Button runat="server" style="height:100%; width:75px;margin-right:10px; float:left;" ID="localhostö44338äViewsäGatehome" OnClick="DirectTO" Text="Home"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44328äViewsäPersonenverwaltung" OnClick="DirectTO" Text="Personenverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:160px;margin-right:10px; float:left;" ID="localhostö44336äViewsäMannschaftsverwaltung" OnClick="DirectTO" Text="Mannschaftsverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44399äViewsäTurnierverwaltung" OnClick="DirectTO" Text="Turnierverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44399äViewsäRankinganzeige" OnClick="DirectTO" Text="RankingView"/>
        <asp:Button runat="server" style="height:100%; width:100px;margin-right:10px; float:right;" ID="btnLogout" Text="Logout" OnClick="LogoutClick"/>
    </div>
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
