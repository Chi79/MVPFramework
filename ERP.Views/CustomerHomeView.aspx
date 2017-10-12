<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHomeView.aspx.cs" EnableEventValidation="false" Inherits="ERP.Views.CustomerHomeView" %>

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
.navigationMessage{
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
.logoutButton{
    position:relative;
    font-size: 45px;
    width: 222px;
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
.Row td{
    text-align:center;
}
.AltRow td{
    text-align:center;
}
.Row:hover{
      border-color:white;
}
.AltRow:hover{  
      border-color:white;
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

    <asp:UpdatePanel runat="server"> 
    <ContentTemplate>

    <asp:GridView 
    ID="gvOrders" 
    CssClass="gvOrders" 
    runat="server"
    HorizontalAlign="Center"
    DataKeyNames="OrderID"
    OnSelectedIndexChanged="gvOrders_SelectedIndexChanged"
    OnRowDataBound="gvOrders_RowDataBound">
    <RowStyle BackColor="#e0d8d8" CssClass="Row"/>

    <AlternatingRowStyle
    CssClass="AltRow"
    VerticalAlign="Middle" 
    Wrap="True"
    BackColor="#f0f0f0" />

    </asp:GridView>

    </ContentTemplate>
    </asp:UpdatePanel>
      

    <div id="searchButtonsDiv" class="searchButtonsDiv0">

    <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div id="navigationMessageDiv" class="messageDiv">

    <asp:Label ID="lblNavigationMessage" class="navigationMessage" runat="server"></asp:Label>

    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

    <div id="searchButtonsDiv1" class="searchButtonsDiv1">

    <asp:Button ID="btnShowAllOrders" CssClass="searchButtons" runat="server" Text="Show All Orders" OnClick="btnShowAllOrders_Click"/>

    <asp:Button ID="btnShowAllConfirmedOrders" CssClass="searchButtons" runat="server" Text="Confirmed Orders" OnClick="btnShowAllConfirmedOrders_Click" />

    <asp:Button ID="btnShowAllOrdersInProduction" CssClass="searchButtons" runat="server" Text="Orders In Production" OnClick="btnShowAllOrdersInProduction_Click" />

    <asp:Button ID="btnShowAllCompletedOrders" CssClass="searchButtons" runat="server" Text="Completed Orders" OnClick="btnShowAllCompletedOrders_Click" />

    </div>

    </div>

    <div id="childDiv" class="childDiv0">

    <div id="childDiv1" class="childDiv1">

    <asp:Button ID="btnLogoutButton" CssClass="logoutButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    </div>

    </div>

    </div>
    
   
    </form>
</body>
</html>
