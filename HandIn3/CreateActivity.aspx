<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="CreateActivity.aspx.cs" Inherits="HandIn3.CreateActivity" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
        <p class="toptext" >Please enter information to create a new activity</p>
        <table class="myTable">
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelActivityNumber" runat="server" Text="Activity number"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxActivityNumber" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td class="text-center" rowspan="5">            
                    <asp:Label ID="LabelSelectText" runat="server" Text="Upload picture:"></asp:Label>
                    <br />
                    <br />      
                    <asp:FileUpload id="FileUploadPicture" runat="server"></asp:FileUpload>
                    <br />
                    <br />
                    <asp:Button id="ButtonUpload" Text="Upload" OnClick="UploadButton_Click" runat="server"></asp:Button>    
                    <br />
                    <br />
                    <asp:Label id="LabelUpload" runat="server"></asp:Label></td>
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
                <asp:TextBox ID="TextBoxTime" runat="server" TextMode="DateTime"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelPicturelink" runat="server" Text="Picturelink"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxPicturelink" runat="server"></asp:TextBox>
                </td>
                <td class="myTableContCol2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelCoachID" runat="server" Text="Coach"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:DropDownList ID="DropDownListCoach" runat="server" OnSelectedIndexChanged="DropDownListCoach_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
                <td class="myTableContCol2">
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
