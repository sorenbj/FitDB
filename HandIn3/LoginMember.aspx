<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMember.aspx.cs" Inherits="HandIn3.LoginMember" Theme="ThemeMyFitness" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="headertext">
            <asp:Label ID="LabelHeader" runat="server" CssClass="headertext" Text="MyFitnessCenter" EnableTheming="False"></asp:Label>
            <br />
        </div> 
        <table class="myTable">
            <tr>
                <td colspan="2">
                    <asp:Label ID="LabelLogin" runat="server" Text="Please enter your login information"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelMemberNumber" runat="server" Text="Member number"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxMemberNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
