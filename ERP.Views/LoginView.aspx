<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="ERP.Views.LoginView"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>


<style type="text/css">


body{
    color: #253131;
    background: #E6DADA; 
    background: -webkit-linear-gradient(to right, #274046, #E6DADA);  
    background: linear-gradient(to right, #274046, #E6DADA); 
}
form1{
    color:#253131;
}
.parent{
    width: 100%;
    height: 500px;
    background: #E6DADA; 
    background: -webkit-linear-gradient(to right, #274046, #E6DADA);
    background: linear-gradient(to right, #274046, #E6DADA); 
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
    font-variant: small-caps;
    font-size: 37px;
    font-weight: bolder;
}
.EmailBox{
    font-size: 32px;
    border-radius: 10px;
    background:honeydew;
}
.PasswordLabel{
    font-variant: small-caps;
    font-size: 37px;
    font-weight: bolder;
}
.PasswordBox{
    font-size: 32px;
    border-radius: 10px;
    background:honeydew;
}
.Message{
    font-variant: small-caps;
    font-size: 32px;
    color: #312b2b;
}
.LoginButton{
    background: #BACFE0;
    background: -webkit-linear-gradient(top, #BACFE0, #6E6E70);
    background-image: -moz-linear-gradient(top, #BACFE0, #6E6E70);
    background-image: -ms-linear-gradient(top, #BACFE0, #6E6E70);
    background-image: -o-linear-gradient(top, #BACFE0, #6E6E70);
    background-image: linear-gradient(to bottom, #BACFE0, #6E6E70);
    -webkit-border-radius: 20px;
    -moz-border-radius: 20px;
    border-radius: 20px;
    color: #000000;
    font-variant: small-caps;
    font-size: 50px;
    font-weight: 200;
    padding: 26px;
    box-shadow: 1px 1px 25px 0px #FFFFFF;
    -webkit-box-shadow: 1px 1px 25px 0px #FFFFFF;
    -moz-box-shadow: 1px 1px 25px 0px #FFFFFF;
    text-shadow: 8px 0px 43px #000000;
    border: solid #FFFFFF 1px;
    text-decoration: none;
    display: inline-block;
    cursor: pointer;
    margin-top: 25px;
}
.LoginButton:hover {
    background: #A8B1BF;
    background-image: -webkit-linear-gradient(top, #ffffff, #8e8686);
    background-image: -moz-linear-gradient(top, #ffffff, #8e8686);
    background-image: -ms-linear-gradient(top, #ffffff, #8e8686);
    background-image: -o-linear-gradient(top, #ffffff, #8e8686);
    background-image: linear-gradient(to bottom, #ffffff, #8e8686);
    text-decoration: none;
}
</style>


<body>

    <form id="form1" runat="server" autocomplete="off">

    <div>

    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 

    <div id="parentDiv" class="parent" runat="server">

    <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div id="loginDiv0" class="loginDiv">

    <asp:Label ID="lblEmail" CssClass="EmailLabel" Text="Email" runat="server"></asp:Label>

    </div>

    <div id="loginDiv1" class="loginDiv">

    <input type="email"  id="txtEmail" class="EmailBox" required="required" runat="server" />

    </div>

    <div id="loginDiv2" class="loginDiv">

    <asp:Label ID="lblPassword" CssClass="PasswordLabel" Text="Password" runat="server"></asp:Label>

    </div>

    <div id="loginDiv3" class="loginDiv">

    <asp:TextBox ID="txtPassword" CssClass="PasswordBox" runat="server" TextMode="Password"></asp:TextBox>

    </div>

    <div id="loginDiv4" class="loginDiv">

    <asp:Button ID="btnLoginButton" CssClass="LoginButton" Text="Login" runat="server" OnClick="btnLoginButton_Click"
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';" />

    </div>

    <asp:Panel ID="messagePanel" CssClass="messagecontainer" runat="server" Visible="false"> 

    <div id="messageDiv" class="messageDiv">

    <asp:Label ID="lblMessage" CssClass="Message" Text="" runat="server"></asp:Label>

    </div>

    </asp:Panel>

    </ContentTemplate>
    </asp:UpdatePanel>

    </div>

    </div>
    </form>
</body>
</html>
