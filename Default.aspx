<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="color:cornflowerblue;" "font-family:verdana;">Classic ADO</h1>
        <table>
            <tr>
                <td class="auto-style1">Email: </td>
                <td class="auto-style1"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password: </td>
                <td><asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="LoginButton_Click" style="height: 35px" /></td>
                <td><asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
