<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="TurnierverwaltungService.Views.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnierverwaltung</title>
</head>
<body>
    <div style="width:100%; height:30px; background-color:grey; margin-top:0px; padding-top:0px;">
        <button onclick="location.href = 'https://localhost:44338/Views/Gatehome';" style="height:100%; width:75px;margin-right:10px; float:left;" id="myButton">Home</button>
        <button onclick="location.href = 'https://localhost:44328/Views/Personenverwaltung';" style="height:100%; width:155px;margin-right:10px; float:left;" id="myButton1">Personenverwaltung</button>
        <button onclick="location.href = 'https://localhost:44336/Views/Mannschaftsverwaltung';" style="height:100%; width:155px;margin-right:10px; float:left;" id="myButton2">Mannschaftsverwaltung</button>
        <button onclick="location.href = 'https://localhost:44399/Views/Turnierverwaltung';" style="height:100%; width:155px;margin-right:10px; float:left;" id="myButton3">Turnierverwaltung</button>
    </div>
    <form id="form1" runat="server">
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
