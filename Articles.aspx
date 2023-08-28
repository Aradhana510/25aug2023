<%@ Page Title="Articles" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="dynamicwebsite.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Articles</h1>
        <hr />
        <asp:Repeater ID="RepeaterArticles" runat="server">
            <ItemTemplate>
                <h2><%# Eval("Title") %></h2>
                <p><strong>Publish Date:</strong> <%# Eval("PublishDate", "{0:dd/MM/yyyy}") %></p>
                <p><%# Eval("Content") %></p>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
