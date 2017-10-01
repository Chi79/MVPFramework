<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeView.aspx.cs" Inherits="ERP.Views.WelcomeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>
    </title>  
</head>

<style type="text/css">

body{
    color: darkslategray;
    background: cornsilk;
}
form1{
    color:darkslategrey;
}
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
.GoToLoginButton{
    position: absolute;
    top: 67%;
    left: 40%;
    font-size: 44px;
    font-variant:small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
}
</style>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="txtWelcomeTitle" CssClass="WelcomeTitle" runat="server" Text=""></asp:Label>
    <asp:Label ID="txtWelcomeMessage" CssClass="WelcomeMessage" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnGoToLoginScreen" CssClass="GoToLoginButton" runat="server" Text="Go To Login" /> 
    </div>
    </form>
</body>
</html>
