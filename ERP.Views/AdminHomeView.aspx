<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomeView.aspx.cs" Inherits="ERP.Views.AdminHomeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
.parent{
    width: 100%;
    height: 500px;
    /*background: cornsilk;*/
    background: #E6DADA; 
    background: -webkit-linear-gradient(to right, #274046, #E6DADA);  /* Chrome 10-25, Safari 5.1-6 */
    background: linear-gradient(to right, #274046, #E6DADA); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
    margin: auto;
    margin-top: 75px;
}
.messageDiv{
    text-align: center;
}
.message{
    font-variant: small-caps;
    font-size: 40px;
    color: #000000;
}
.childDiv{
    text-align: center;
}
.logoutButton{
    /*font-size: 45px;
    width: 222px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
    margin-top: 210px;
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
    font-size: 32px;
    font-weight: 200;
    padding: 11px;
    box-shadow: 7px 1px 34px -6px #FFFFFF;
    -webkit-box-shadow: 7px 1px 34px -6px #FFFFFF;
    -moz-box-shadow: 7px 1px 34px -6px #FFFFFF;
    text-shadow: 8px 0px 43px #000000;
    border: solid #FFFFFF 1px;
    text-decoration: none;
    display: inline-block;
    cursor: pointer;
}
.navButton:hover {
    background: #A8B1BF;
    background-image: -webkit-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -moz-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -ms-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -o-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: linear-gradient(to bottom, #A8B1BF, #CAB0D4);
    text-decoration: none;
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
