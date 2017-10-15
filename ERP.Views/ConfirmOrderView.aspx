<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmOrderView.aspx.cs" Inherits="ERP.Views.ConfirmOrderView" %>

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
    margin-top: 5px;
}
.messageDiv{
    text-align: center;
    margin-top: 0px;
}
.infoMessageDiv{
    text-align: center;
    margin-top:0px;
}
.message{
    font-variant: small-caps;
    font-size: 40px;
    color: #000000;
}
.infoMessage{
    font-variant: small-caps;
    font-size: 30px;
    font-weight:bolder;
    color: #000000;
}
.childDiv0{
    position: fixed;
    width: 100%;
    bottom:15px;
}
.childDiv1{
    text-align: center;
}
.navButton{
    position:relative;
    font-size: 30px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
}
.searchButtonsDiv0{
    position:fixed;
    width:100%;
    top:130px;
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
.div1{
    display: inline-block;
    width: 200px;
}
.divGrid{
    display:inline-block;
    width: 525px;
}
.gvItems{
    font-size: 40px;
    background: #b1bcfe;
    margin-bottom: 28px;
}
td{
    text-align:center;
}



</style>
    <form id="form1" runat="server">
    <div id="parentDiv" class="parent" runat="server">

    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 

    <asp:UpdatePanel runat="server"><ContentTemplate>

    <div id="messageDiv" class="messageDiv">

    <asp:Label ID="lblMessage" CssClass="message" runat="server" Visible="false"></asp:Label>

    </div>

    </ContentTemplate></asp:UpdatePanel>
      

    <div id="searchButtonsDiv" class="searchButtonsDiv0">

    <asp:UpdatePanel runat="server">
    <ContentTemplate>



    <div id="searchButtonsDiv1" class="searchButtonsDiv1">

    <div id="divCartList" class="divGrid" runat="server">

    <asp:GridView 
    ID="gvItems" 
    CssClass="gvItems"
    runat="server"
    HorizontalAlign="Center"
    OnRowCreated="gvItems_RowCreated">   

    <RowStyle BackColor="#e0d8d8" CssClass="Row"/>

    <AlternatingRowStyle
    CssClass="AltRow"
    VerticalAlign="Middle" 
    Wrap="True"
    BackColor="#f0f0f0" />

    </asp:GridView>

    <asp:Button ID="btnPlaceOrder" CssClass="navButton" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click"  />

    </div>

    </div>

    <div id="infoMessageDiv" class="infoMessageDiv">

    <asp:Label ID="lblInfoMessage" class="infoMessage" runat="server"></asp:Label>

    </div>


    </ContentTemplate>
    </asp:UpdatePanel>

    </div>



    <div id="childDiv" class="childDiv0">

    <div id="childDiv1" class="childDiv1">

    <asp:Button ID="btnLogoutButton" CssClass="navButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    <asp:Button ID="btnEditOrder" CssClass="navButton" runat="server" Text="Edit Order" OnClick="btnEditOrder_Click" />

    <asp:Button ID="btnViewAllOrders" CssClass="navButton" runat="server" Text="View All Orders" OnClick="btnViewAllOrders_Click" />

    </div>

    </div>

    </div>
    
   
    </form>
</body>
</html>
