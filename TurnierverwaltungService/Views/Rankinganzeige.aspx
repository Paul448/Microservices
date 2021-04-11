<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rankinganzeige.aspx.cs" Inherits="TurnierverwaltungService.Views.Rankinganzeige" %>

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
        <asp:Button runat="server" style="height:100%; width:100px;margin-right:10px; float:right;" ID="btnLogout" Text="Logout" OnClick="LogoutClick"/>
    </div>
        <div>
            <h1>Rankinganzeige</h1>
            <h3>Bitte wählen sie ein Turnier</h3>
            <asp:DropDownList runat="server" ID="DDTurnier" OnSelectedIndexChanged="DDTurnier_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <br />
            <h3>Rankingtabelle</h3>
            <asp:Table runat="server" ID="tblRanking" BorderStyle="Solid"  CellPadding = "5" 
            CellSpacing="0"
            GridLines="Both"
            BorderWidth="3"></asp:Table>
        </div>
    </form>
</body>
</html>
