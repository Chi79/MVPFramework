﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeView.aspx.cs" Inherits="ERP.Views.WelcomeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>
    </title>  
</head>

<style type="text/css">

.WelcomeTitle{
    position: absolute;
    left: 32%;
    top: 10%;
    font-size: 100px;
    font-weight: bolder;
}
.WelcomeMessage{
    position: absolute;
    left: 34%;
    top: 39%;
    font-size: 35px;
}
</style>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="txtWelcomeTitle" CssClass="WelcomeTitle" runat="server" Text=""></asp:Label>
    <asp:Label ID="txtWelcomeMessage" CssClass="WelcomeMessage" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>