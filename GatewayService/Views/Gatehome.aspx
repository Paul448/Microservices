<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gatehome.aspx.cs" Inherits="GatewayService.Views.Gatehome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div style="width:100%; height:30px; background-color:grey; margin-top:0px; padding-top:0px;">
        <asp:Button runat="server" style="height:100%; width:75px;margin-right:10px; float:left;" ID="localhostö44338äViewsäGatehome" OnClick="DirectTO" Text="Home"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44328äViewsäPersonenverwaltung" OnClick="DirectTO" Text="Personenverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:160px;margin-right:10px; float:left;" ID="localhostö44336äViewsäMannschaftsverwaltung" OnClick="DirectTO" Text="Mannschaftsverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44399äViewsäTurnierverwaltung" OnClick="DirectTO" Text="Turnierverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44399äViewsäRankinganzeige" OnClick="DirectTO" Text="RankingView"/>
        <asp:Button runat="server" style="height:100%; width:100px;margin-right:10px; float:right;" ID="btnLogout" Text="Login" OnClick="LogoutClick"/>
    </div> <br /> 
        <div>   
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/> <br />
            <asp:Button ID="btnAdmin" runat="server" Text="Admin-Panel (OLD)" OnClick="btnAdmin_Click"/> <br />
            <asp:Button ID="btnPS" runat="server" Text="User/Personenverwaltung" OnClick="btnPS_Click"/> <br />
            <asp:Button ID="btnTurnier" runat="server" Text="Turnierverwaltung" OnClick="btnTurnier_Click"/> <br />
            <asp:Button ID="btnMannschaft" runat="server" Text="Mannschaftsverwaltung" OnClick="btnMannschaft_Click"/> <br />
            <asp:Label ID="lblAuth" runat="server" Text="Auth: Error"></asp:Label> 
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
