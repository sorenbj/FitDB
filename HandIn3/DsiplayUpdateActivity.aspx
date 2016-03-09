<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="DsiplayUpdateActivity.aspx.cs" Inherits="HandIn3.DsiplayUpdateActivity" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
    <p class="toptext" >Please select an activity to update information</p>
    <p>
    <asp:GridView ID="GridViewUpdate" runat="server" OnSelectedIndexChanged="GridViewUpdate_SelectedIndexChanged" AutoGenerateColumns="True" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </p>
    <p>
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    </p>
    <div>
        <table class="myTable">
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelActivityNumber" runat="server" Text="Activity number"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxActivityNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelTitle" runat="server" Text="Title"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelDescription" runat="server" Text="Description"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelWeekday" runat="server" Text="Weekday"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxWeekday" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelTime" runat="server" Text="Time"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelPicturelink" runat="server" Text="Picturelink"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxPicturelink" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelCoachID" runat="server" Text="Coach Number"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxCoachNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
        <br />
    </div>
</asp:Content>
