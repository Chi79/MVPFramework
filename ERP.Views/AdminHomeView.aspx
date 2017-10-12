<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomeView.aspx.cs" Inherits="ERP.Views.AdminHomeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<style type="text/css">

body{
    color: darkslategray;
    background: cornsilk;
}
form1{
    color:darkslategrey;
}
.parent{
    width: 100%;
    height: 500px;
    background: cornsilk;
    margin: auto;
    margin-top: 75px;
}
.messageDiv{
    text-align: center;
}
.message{
    font-size: 40px;
    color: #000000;
}
.childDiv{
    text-align: center;
}
.logoutButton{
    font-size: 45px;
    width: 222px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
    margin-top: 210px;
}
</style>


    <form id="form1" runat="server">

    <div id="parentDiv" class="parent" runat="server">

    <div id="messageDiv" class="messageDiv">

    <asp:Label ID="lblMessage" CssClass="message" runat="server" Visible="false"></asp:Label>

    </div>

    <div id="childDiv" class="childDiv">

    <asp:Button ID="btnLogoutButton" CssClass="logoutButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    </div>

    </div>
    
   
    </form>
</body>
</html>
