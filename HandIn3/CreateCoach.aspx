<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="CreateCoach.aspx.cs" Inherits="HandIn3.CreateCoach" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
        <p class="toptext" >Please enter information to create a new coach</p>
        <table class="myTable">
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelCoachNumber" runat="server" Text="Coach number"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxCoach" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxPhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Submit" />
        <br />
    </div>
</asp:Content>
