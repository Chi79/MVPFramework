<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrderView.aspx.cs" Inherits="ERP.Views.CreateOrderView" %>

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
.gvOrders{
    margin-top: 25px;
    font-size: 30px;
    background: #b1bcfe;
}
.parent{
    width: 100%;
    height: 500px;
    background: cornsilk;
    margin: auto;
    margin-top: 50px;
}
.messageDiv{
    text-align: center;
}
.message{
    font-variant: small-caps;
    font-size: 40px;
    color: #000000;
}
.infoMessage{
    font-variant: small-caps;
    font-size: 30px;
    color: #000000;
}
.childDiv0{
    position: fixed;
    width: 100%;
    bottom:60px;
}
.childDiv1{
    text-align: center;
}
.navButton{
    position:relative;
    font-size: 45px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
}
.searchButtonsDiv0{
    position:fixed;
    width:100%;
    bottom:145px;
}
.searchButtonsDiv1{
    text-align:center;
}
.searchButtons{
    font-size: 32px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
    margin-top: 25px;
}


</style>
    <form id="form1" runat="server">
    <div id="parentDiv" class="parent" runat="server">

    <div id="messageDiv" class="messageDiv">

    <asp:Label ID="lblMessage" CssClass="message" runat="server" Visible="false"></asp:Label>

    </div>

    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 
      

    <div id="searchButtonsDiv" class="searchButtonsDiv0">

    <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div id="datanMessageDiv" class="messageDiv">

    <asp:Label ID="lblInfoMessage" class="infoMessage" runat="server"></asp:Label>


    <div id="searchButtonsDiv1" class="searchButtonsDiv1">

<%--    <asp:Button ID="btnShowAllOrders" CssClass="searchButtons" runat="server" Text="Show All Orders" OnClick="btnShowAllOrders_Click"/>

    <asp:Button ID="btnShowAllConfirmedOrders" CssClass="searchButtons" runat="server" Text="Confirmed Orders" OnClick="btnShowAllConfirmedOrders_Click" />

    <asp:Button ID="btnShowAllOrdersInProduction" CssClass="searchButtons" runat="server" Text="Orders In Production" OnClick="btnShowAllOrdersInProduction_Click" />

    <asp:Button ID="btnShowAllCompletedOrders" CssClass="searchButtons" runat="server" Text="Completed Orders" OnClick="btnShowAllCompletedOrders_Click" />--%>

    </div>

    </div>

    </ContentTemplate>
    </asp:UpdatePanel>

    </div>

    <div id="childDiv" class="childDiv0">

    <div id="childDiv1" class="childDiv1">

    <asp:Button ID="btnLogoutButton" CssClass="navButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    <asp:Button ID="btnViewOrders" CssClass="navButton" runat="server" Text="View Orders" OnClick="btnViewOrders_Click" />

    </div>

    </div>

    </div>
    
   
    </form>
</body>
</html>

