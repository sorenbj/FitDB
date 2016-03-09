<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="HandIn3.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    <br />
        <div class="container">
            <asp:Repeater ID="RepeaterWelcome" runat="server">      
            <ItemTemplate>
                <div class="col-sm-6 col-md-3">
                    <img src="Pictures/<%# Eval("PictureLink") %>" alt="fitness" width="175" height="120" />
                    <h3 class="myitem"><%# Eval("Title") %></h3>
                    <h4 class="myitem"><%# Eval("Weekday") %> at <%# Eval("Time") %></h4> 
                    <br />               
                </div>                          
            </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterSponsor" runat="server">              
                <ItemTemplate>
                <div class="col-sm-6 col-md-3">
                    <img src="Pictures - sponsor/<%# Eval("Picture") %>" alt="logo" width="175" height="120" />
                    <br />               
                </div>                          
            </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
