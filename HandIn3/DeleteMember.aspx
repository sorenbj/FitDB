<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="DeleteMember.aspx.cs" Inherits="HandIn3.DeleteMember" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
        <p class="toptext" >Delete members</p>
        <asp:GridView ID="GridViewMember" runat="server" AutoGenerateColumns="True" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        </asp:GridView>       
        <br />
        <br />
        <asp:DropDownList ID="DropDownListMember" runat="server" OnSelectedIndexChanged="DropDownListMember_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
        <br />
    </div>
</asp:Content>
