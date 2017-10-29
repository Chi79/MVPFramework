<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeView.aspx.cs" Inherits="ERP.Views.WelcomeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>
    </title>  
</head>

<style type="text/css">

body{
    color: #253131;
    /*background: cornsilk;*/
    background: #E6DADA; 
    background: -webkit-linear-gradient(to right, #274046, #E6DADA);  /* Chrome 10-25, Safari 5.1-6 */
    background: linear-gradient(to right, #274046, #E6DADA); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */



}
form1{
    color:#253131;
}
.labelDiv{
    text-align:center;
    margin-bottom: 37px;
    margin-top: 63px;
}
.WelcomeTitle{
    font-variant: small-caps;
    font-size: 100px;
    font-weight: bolder;
}
.WelcomeMessage{
    font-variant: small-caps;
    font-size: 35px;
}
.GoToLoginButton{
    /*font-size: 44px;
    font-variant:small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
    cursor:pointer*/
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
}
.GoToLoginButton:hover {
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
    <form id="form1" runat="server">

    <div id="labelDiv0" class="labelDiv" >

        <asp:Label ID="txtWelcomeTitle" CssClass="WelcomeTitle" runat="server" Text=""></asp:Label> 

    </div>

    <div id="labelDiv1" class="labelDiv">

        <asp:Label ID="txtWelcomeMessage" CssClass="WelcomeMessage" runat="server" Text=""></asp:Label> 

    </div>

    <div id="labelDiv2" class="labelDiv">

        <asp:Button ID="btnGoToLoginScreen" CssClass="GoToLoginButton" runat="server" Text="Go To Login" OnClick="btnGoToLoginScreen_Click" />

    </div>

    </form>
</body>
</html>
