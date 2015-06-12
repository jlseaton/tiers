<%@ Page Title="Tiers WebForms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tiers.WebForms._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Test the Service and WebApi layers</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Tests:</h3>
    <ol class="round">
        <li class="one">
            <h5>Call WebApi to get users w/out sensitive data</h5>
            <asp:Button runat="server" Text="Get from WebApi" ID="buttonWebApi" OnClick="buttonWebApi_Click" /><br />
            <asp:TextBox runat="server" ID="textBoxWebApiResult" Height="96px" TextMode="MultiLine" Width="388px"></asp:TextBox>
        </li>
        <li class="two">
            <h5>Call Service layer directly to get a public list of users w/out sensitive data</h5>
            <asp:Repeater ID="userRepeater" runat="server">
              <ItemTemplate>
                <span>ID: <%# Eval("ID") %></span>
                <span>Name: <%# Eval("Name") %></span>
                <span>Data: <%# Eval("Data") %></span>
              </ItemTemplate>
            </asp:Repeater>
        </li>
        <li class="three">
            <h5>Call Service layer directly to get one random user with data</h5>
            ID: <%= model.User.ID %>
            Name: <%= model.User.Name %>
            Data: <%= model.User.Data %>
        </li>
    </ol>
</asp:Content>
