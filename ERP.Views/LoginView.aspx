<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="ERP.Views.LoginView"  %>

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
.parent{
    width: 100%;
    height: 500px;
    background: cornsilk;
    margin: auto;
    margin-top: 75px;
}
.loginDiv{
    text-align: center;
    margin-top: 10px;
    margin-bottom:10px;
}
.messageDiv{
    text-align: center;
}
.messagecontainer{
    background-color: #b7b7b7;
    border: #555d55;
    border-bottom-style: solid;
    border-bottom-width: 7px;
    border-radius: 30px;
    z-index: 30;
    width: 540px;
    margin-left: auto;
    margin-right: auto;
    margin-top: 75px;
}
.EmailLabel{
    font-size: 37px;
    font-weight: bolder;
}
.EmailBox{
    font-size: 32px;
}
.PasswordLabel{
    font-size: 37px;
    font-weight: bolder;
}
.PasswordBox{
    font-size: 32px;
}
.Message{
    font-size: 32px;
    color: #312b2b;
}
.LoginButton{
    font-size: 45px;
    width: 222px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
    margin-top: 35px;
}
</style>


<body>

    <form id="form1" runat="server" autocomplete="off">

    <div>

    <div id="parentDiv" class="parent" runat="server">

    <div id="loginDiv0" class="loginDiv">

    <asp:Label ID="lblEmail" CssClass="EmailLabel" Text="Email" runat="server"></asp:Label>

    </div>

    <div id="loginDiv1" class="loginDiv">

    <asp:TextBox ID="txtEmail" CssClass="EmailBox" runat="server"></asp:TextBox>

    </div>

    <div id="loginDiv2" class="loginDiv">

    <asp:Label ID="lblPassword" CssClass="PasswordLabel" Text="Password" runat="server"></asp:Label>

    </div>

    <div id="loginDiv3" class="loginDiv">

    <asp:TextBox ID="txtPassword" CssClass="PasswordBox" runat="server" TextMode="Password"></asp:TextBox>

    </div>

    <div id="loginDiv4" class="loginDiv">

    <asp:Button ID="btnLoginButton" CssClass="LoginButton" Text="Login" runat="server" OnClick="btnLoginButton_Click" />

    </div>

    <asp:Panel ID="messagePanel" CssClass="messagecontainer" runat="server" Visible="false"> 

    <div id="messageDiv" class="messageDiv">

    <asp:Label ID="lblMessage" CssClass="Message" Text="" runat="server"></asp:Label>

    </div>

    </asp:Panel>

    </div>

    </div>
    </form>
</body>
</html>
