<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rankinganzeige.aspx.cs" Inherits="TurnierverwaltungService.Views.Rankinganzeige" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
