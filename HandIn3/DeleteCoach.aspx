<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="DeleteCoach.aspx.cs" Inherits="HandIn3.DeleteCoach" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
        <p class="toptext" >Delete coaches</p>
        <asp:GridView ID="GridViewCoaches" runat="server" AutoGenerateColumns="True" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        </asp:GridView>       
        <br />
        <asp:DropDownList ID="DropDownListCoach" runat="server" OnSelectedIndexChanged="DropDownListCoaches_SelectedIndexChanged" Font-Names="Tahoma" Font-Size="Small" Width="300px">
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
