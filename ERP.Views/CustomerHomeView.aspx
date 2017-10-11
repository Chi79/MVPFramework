﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHomeView.aspx.cs" EnableEventValidation="false" Inherits="ERP.Views.CustomerHomeView" %>

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
    font-size: 32px;
    color: #312b2b;
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
    margin-top: 150px;
}
.searchButtonsDiv{
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
      color:white;
}
.AltRow:hover{
      color:white;   
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
    <SelectedRowStyle 
    BackColor="#b1bcfe" ForeColor="#ffffff" />

    </asp:GridView>

    </ContentTemplate>
    </asp:UpdatePanel>
      

    <div id="searchButtonsDiv" class="searchButtonsDiv">

    <asp:Button ID="btnShowAllOrders" CssClass="searchButtons" runat="server" Text="Show All Orders" OnClick="btnShowAllOrders_Click"/>

    <asp:Button ID="btnShowAllConfirmedOrders" CssClass="searchButtons" runat="server" Text="Confirmed Orders" OnClick="btnShowAllConfirmedOrders_Click" />

    <asp:Button ID="btnShowAllOrdersInProduction" CssClass="searchButtons" runat="server" Text="Orders In Production" OnClick="btnShowAllOrdersInProduction_Click" />

    <asp:Button ID="btnShowAllCompletedOrders" CssClass="searchButtons" runat="server" Text="Completed Orders" OnClick="btnShowAllCompletedOrders_Click" />

    <asp:Button ID="btnShowAllItemsInOrder" CssClass="searchButtons" runat="server" Text="Items in Order" OnClick="btnShowAllItemsInOrder_Click" />

    </div>

    <div id="childDiv" class="childDiv">

    <asp:Button ID="btnLogoutButton" CssClass="logoutButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    </div>

    </div>
    
   
    </form>
</body>
</html>
