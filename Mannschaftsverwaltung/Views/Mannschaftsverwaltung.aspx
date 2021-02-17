<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung.Views.Mannschaftsverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mannschaftsverwaltung</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Mannschaftsverwaltung</h1> <br />
            <asp:DropDownList ID="selectTeam" runat="server" AutoPostBack="true" OnSelectedIndexChanged="selectTeam_SelectedIndexChanged">
                <asp:ListItem>Mannschaften</asp:ListItem>
            </asp:DropDownList> <br />
            <asp:Table ID="tblPersonen" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableCell>Person-ID</asp:TableCell>
                    <asp:TableCell>Name</asp:TableCell>
                    <asp:TableCell>Geburtsdatum</asp:TableCell>
                    <asp:TableCell>Mannschafts-ID</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
