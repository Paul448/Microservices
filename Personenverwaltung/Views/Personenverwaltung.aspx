<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="Personenverwaltung.Views.Personenverwaltung" %>

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
        <asp:Button runat="server" style="height:100%; width:100px;margin-right:10px; float:right;" ID="btnLogout" Text="LOGOUT" OnClick="LogoutClick"/>
    </div>
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
            </asp:Table> <br />
            <h3>USER Hinzufügen</h3> <br />
            NAME:<asp:TextBox ID="txtNewUsername" runat="server"></asp:TextBox> <br />
            Status <asp:DropDownList ID="newUserStatus" runat="server">
                        <asp:ListItem>USER</asp:ListItem>
                        <asp:ListItem>ADMIN</asp:ListItem>
                   </asp:DropDownList> <br />
            <asp:TextBox ID="txtUserAddPW" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
