<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="MemberCRUD.aspx.cs" Inherits="HandIn3.MemberCRUD" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
        <p class="toptext" >You are signup for the following activity</p>
        <asp:GridView ID="GridViewMember" runat="server" EmptyDataText="You are not signed up for any activities" width=600px AutoGenerateColumns="True" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        </asp:GridView>
        <br />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        <br />
    </div>
</asp:Content>
