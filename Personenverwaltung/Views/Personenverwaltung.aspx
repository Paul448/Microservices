<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Personenverwaltung.Views.Personenverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Personenverwaltung</h1> <br />
            <asp:Table runat="server" ID="tblPersonen">
                <asp:TableHeaderRow>
                    <asp:TableCell>ID:</asp:TableCell>
                    <asp:TableCell>Name:</asp:TableCell>
                    <asp:TableCell>TYP:</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table> <br />
            <h3>Person Hinzufügen:</h3>
            Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox> 
            TYP: <asp:TextBox ID="txtTYP" runat="server"></asp:TextBox> <br />
            <asp:Button runat="server" ID="btnADD" Text="ADD" OnClick="btnADD_Click"/> <br />
            <h3>Person Löschen</h3>
            <asp:TextBox runat="server" ID="txtDel" TextMode="Number"></asp:TextBox>
            <asp:Button runat="server" ID="btnDEL" Text="DEL" OnClick="btnDEL_Click"/> <br />
            <h1>Userverwaltung</h1> <br />
            <asp:Table runat="server" ID="tblUser">
                <asp:TableHeaderRow>
                    <asp:TableCell>UID:</asp:TableCell>
                    <asp:TableCell>Name:</asp:TableCell>
                    <asp:TableCell>Status:</asp:TableCell>
                    <asp:TableCell>Info:</asp:TableCell>
                    <asp:TableCell>Hash:</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
