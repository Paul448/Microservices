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
            <asp:DropDownList ID="selectTeam" runat="server">
                <asp:ListItem>Mannschaft1</asp:ListItem>
                <asp:ListItem>Mannschaft2</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
