<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Button runat="server" ID="nocrediteUserBtn" Text="NoCrediteUsers" OnClick="nocrediteUserBtn_Click"/>
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="nocrediteOrgnoBtn" Text="NoCrediteOrgno" OnClick="nocrediteOrgnoBtn_Click"/>
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="alladdressesBtn" Text="AllUserAddresses" OnClick="alladdressesBtn_Click"/>
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="nocrediteAddrs" Text="NoCrediteAddrs" OnClick="nocrediteAddrs_Click"/>
        </div>
    </div>
  
</asp:Content>
