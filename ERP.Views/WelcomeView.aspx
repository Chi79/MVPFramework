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
.labelDiv{
    text-align:center;
    margin-bottom: 37px;
    margin-top: 63px;
}
.WelcomeTitle{
    font-size: 100px;
    font-weight: bolder;
}
.WelcomeMessage{
    font-size: 35px;
}
.GoToLoginButton{
    font-size: 44px;
    font-variant:small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
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
