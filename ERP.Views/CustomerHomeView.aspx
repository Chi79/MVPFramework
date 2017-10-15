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
.parent{
    width: 100%;
    height: 500px;
    background: cornsilk;
    margin: auto;
    margin-top: 30px;
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
    bottom:135px;
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
.divGrid{
    margin-top: 20px;
    overflow: auto;
    width:max-content;
    margin-left: auto;
    margin-right: auto;
    height: 300px;
}
.gvOrders{
    font-size: 30px;
    background: #b1bcfe;
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

    <div id="divGrid" class="divGrid">

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

    </div>

    </ContentTemplate>
    </asp:UpdatePanel>
      

    <div id="searchButtonsDiv" class="searchButtonsDiv0">

    <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div id="datanMessageDiv" class="messageDiv">

    <asp:Label ID="lblInfoMessage" class="infoMessage" runat="server"></asp:Label>


    <div id="searchButtonsDiv1" class="searchButtonsDiv1">

    <asp:Button ID="btnShowAllOrders" CssClass="searchButtons" runat="server" Text="Show All Orders" OnClick="btnShowAllOrders_Click"/>

    <asp:Button ID="btnShowAllConfirmedOrders" CssClass="searchButtons" runat="server" Text="Confirmed Orders" OnClick="btnShowAllConfirmedOrders_Click" />

    <asp:Button ID="btnShowAllOrdersInProduction" CssClass="searchButtons" runat="server" Text="Orders In Production" OnClick="btnShowAllOrdersInProduction_Click" />

    <asp:Button ID="btnShowAllCompletedOrders" CssClass="searchButtons" runat="server" Text="Completed Orders" OnClick="btnShowAllCompletedOrders_Click" />

    </div>

    </div>

    </ContentTemplate>
    </asp:UpdatePanel>

    </div>

    <div id="childDiv" class="childDiv0">

    <div id="childDiv1" class="childDiv1">

    <asp:Button ID="btnLogoutButton" CssClass="navButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    <asp:Button ID="btnCreateNewOrder" CssClass="navButton" runat="server" Text="Create New Order" OnClick="btnCreateNewOrder_Click" />

    </div>

    </div>

    </div>
    
   
    </form>
</body>
</html>
