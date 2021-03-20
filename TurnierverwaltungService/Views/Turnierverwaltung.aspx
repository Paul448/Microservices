<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="TurnierverwaltungService.Views.Turnierverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnierverwaltung</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Turnierverwaltung</h1> <br />
            <h3>Turniere:</h3>
            <asp:DropDownList ID="DDTurnier" runat="server"></asp:DropDownList> <br />
            <h3>Teilnehmende Mannschaften</h3> 
            <asp:Table runat="server" ID="TblMS"></asp:Table>
            <h3>Spiele</h3>
            <asp:Table ID="tblSpiele" runat="server"></asp:Table> <br />
            Spiel Hinzufügen: <br />
            Mannschaft 1: <asp:DropDownList></asp:DropDownList> <br />
            Mannschaft 2: <asp:DropDownList></asp:DropDownList> <br />
            Ergebnis (MS1): <asp:TextBox ID="txtErgebnisMS1" runat="server" TextMode="Number"></asp:TextBox> <br />
            Ergebnis (MS2): <asp:TextBox ID="txtErgebnisMS2" runat="server" TextMode="Number"></asp:TextBox> <br />
            <asp:Button ID="btnAddSpiel" runat="server" Text="OK" />
        </div>
    </form>
</body>
</html>
