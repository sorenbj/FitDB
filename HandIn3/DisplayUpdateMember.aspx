<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="DisplayUpdateMember.aspx.cs" Inherits="HandIn3.DisplayUpdateMember" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label>
        </p>
        <p class="toptext" >Please select a member to update information</p>
        <asp:GridView ID="GridViewUpdate" runat="server" OnSelectedIndexChanged="GridViewUpdate_SelectedIndexChanged" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        <br />
        <br />
        <table class="myTable">
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
                <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
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
                <asp:Label ID="LabelPhoneNumber" runat="server" Text="Phone"></asp:Label>
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
                <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
    </div>
</asp:Content>
