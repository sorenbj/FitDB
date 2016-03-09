<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="HandIn3.ErrorPage" Theme="ThemeMyFitness" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HandIn 3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="headertext">
        <asp:Label ID="LabelHeader" runat="server" CssClass="headertext" Text="MyFitnessCenter" EnableTheming="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelError" runat="server" Text="You have to be logged in to see the content of the page"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonReturn" runat="server" OnClick="ButtonReturn_Click" Text="Go to Login" />
    </div>
    </form>
</body>
</html>
