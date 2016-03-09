<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="DisplayEventSignUp.aspx.cs" Inherits="HandIn3.DisplayEventSignUp" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
            <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label></p>
        <p class="toptext" >Select an Activity to display signup</p>
        <asp:GridView ID="GridViewActivity" runat="server" OnSelectedIndexChanged="GridViewUpdate_SelectedIndexChanged" AutoGenerateColumns="True" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        </asp:GridView>
        <p >
        </p>
        <p >
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        </p>
        <p >
        </p>
        <p >
        <asp:GridView ID="GridViewSignUp" runat="server" EmptyDataText="No members are signed up" AutoGenerateColumns="True" CssClass="GridViewStyle">            
             <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        </asp:GridView>
        </p>
    </div>
</asp:Content>
