<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="TurnierverwaltungService.Views.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnierverwaltung</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; height:30px; background-color:grey; margin-top:0px; padding-top:0px;">
        <asp:Button runat="server" style="height:100%; width:75px;margin-right:10px; float:left;" ID="localhostö44338äViewsäGatehome" OnClick="DirectTO" Text="Home"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44328äViewsäPersonenverwaltung" OnClick="DirectTO" Text="Personenverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:160px;margin-right:10px; float:left;" ID="localhostö44336äViewsäMannschaftsverwaltung" OnClick="DirectTO" Text="Mannschaftsverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:150px;margin-right:10px; float:left;" ID="localhostö44399äViewsäTurnierverwaltung" OnClick="DirectTO" Text="Turnierverwaltung"/>
        <asp:Button runat="server" style="height:100%; width:100px;margin-right:10px; float:right;" ID="btnLogout" Text="LOGOUT"/>
    </div>
        <div>
            <h1>Turnierverwaltung</h1> <br />
            <h3>Turniere:</h3>
            <asp:DropDownList ID="DDTurnier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDTurnier_SelectedIndexChanged"></asp:DropDownList> <br />
            <h3>Teilnehmende Mannschaften</h3> 
            <asp:Table runat="server" ID="TblMS" BorderStyle="Dashed"></asp:Table>
            <h3>Spiele</h3> 
            <asp:Table ID="tblSpiele" runat="server" BorderStyle="Dashed"></asp:Table> <br />
            <h3>Teilnehmende Mannschaft Hinzufügen</h3> <br />
            <asp:DropDownList runat="server" ID="ddMSHinzu" ></asp:DropDownList> <br />
            <asp:Button runat="server" Text="Hinzufügen" ID="btnAddMS" OnClick="btnAddMS_Click" />
            <h3>Spiel Hinzufügen: </h3> <br />
            Mannschaft 1: <asp:DropDownList runat="server" ID="ddMS1"></asp:DropDownList> <br />
            Mannschaft 2: <asp:DropDownList runat="server" ID="ddMS2"></asp:DropDownList> <br />
            Ergebnis (MS1): <asp:TextBox ID="txtErgebnisMS1" runat="server" TextMode="Number"></asp:TextBox> <br />
            Ergebnis (MS2): <asp:TextBox ID="txtErgebnisMS2" runat="server" TextMode="Number"></asp:TextBox> <br />
            <asp:Button ID="btnAddSpiel" runat="server" Text="OK" OnClick="btnAddSpiel_Click" />
        </div>
    </form>
</body>
</html>
