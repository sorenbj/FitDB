<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="SponsorCRUD.aspx.cs" Inherits="HandIn3.SponsorCRUD" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <p class="myUserlevel" >
                <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label>
            </p>
            <p class="toptext" >Maintain Sponsors</p>         
            <asp:DropDownList ID="DropDownListSponsor" runat="server" Width="150px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            <br />
            <br />
            <table class="myTable">
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelSponsorID" runat="server" Text="Sponsor ID"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxID" runat="server" BackColor="#cccccb" ReadOnly="True"></asp:TextBox>
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
                <asp:Label ID="LabelCompanyName" runat="server" Text="Company Name"></asp:Label>
                </td>
                <td class="auto-style2">
                <asp:TextBox ID="TextBoxCompanyName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelWebsite" runat="server" Text="Website"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxWebsite" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                <asp:Label ID="LabelPicture" runat="server" Text="Picture"></asp:Label>
                </td>
                <td class="myTableContCol2">
                <asp:TextBox ID="TextBoxPicture" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    &nbsp;</td>
                <td class="myTableContCol2">
                    &nbsp;</td>
            </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Create" />
            &nbsp;
            <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
            &nbsp;
            <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
            &nbsp;
            <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Cancel" />
            <br />
            <br />
            <br />
            <asp:Repeater ID="RepeaterSponsor" runat="server">
            <HeaderTemplate>
                <table class="myTable">
                    <tr>
                        <td>Sponsor ID</td>
                        <td>Company Name</td>
                        <td>Website</td>
                        <td>Picturelink</td>
                        <td>Logo</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("id") %></td>
                    <td><%# Eval("companyname") %></td>
                    <td><a><%# Eval("website") %></a></td>
                    <td><%# Eval("picture") %></td>
                    <td><img src="Pictures - sponsor/<%# Eval("picture") %>" alt="logo" width="150" height="100" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>
</asp:Content>
