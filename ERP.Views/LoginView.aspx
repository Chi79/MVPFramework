<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="ERP.Views.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<style type="text/css">

body{
    color: darkslategray;
    background: cornsilk;
}
form1{
    color:darkslategrey;
}
.EmailLabel{
    position: absolute;
    top: 18%;
    left: 29%;
    font-size: 37px;
    font-weight:bolder;
}
.EmailBox{
    position: absolute;
    font-size: 32px;
    top: 18%;
    left: 37%;
}
.PasswordLabel{
    position: absolute;
    top: 32%;
    left: 25%;
    font-size: 37px;
    font-weight:bolder;
}
.PasswordBox{
    position: absolute;
    top: 32%;
    left: 37%;
    font-size: 32px;
}
.Message{
    position: absolute;
    top: 75%;
    left: 34%;
    font-size: 32px;
}
.LoginButton{
    position: absolute;
    top: 53%;
    left: 43%;
    font-size: 45px;
    width: 222px;
    font-variant:small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
}
</style>

<body>
    <form id="form1" runat="server">
    <div>

    <asp:Label ID="lblEmail" CssClass="EmailLabel" Text="Email" runat="server"></asp:Label>
    <asp:TextBox ID="txtEmail" CssClass="EmailBox" runat="server"></asp:TextBox>
    <asp:Label ID="lblPassword" CssClass="PasswordLabel" Text="Password" runat="server"></asp:Label>
    <asp:TextBox ID="txtPassword" CssClass="PasswordBox" runat="server"></asp:TextBox>
    <asp:Label ID="lblMessage" CssClass="Message" Text="" runat="server"></asp:Label>
    <asp:Button ID="btnLoginButton" CssClass="LoginButton" Text="Login" runat="server" OnClick="btnLoginButton_Click" />

    </div>
    </form>
</body>
</html>
