﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrderView.aspx.cs" Inherits="ERP.Views.CreateOrderView" MasterPageFile="~/MasterView.Master" %>



<asp:Content ContentPlaceHolderID="head" runat="server">


    <title></title>


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
    margin-top: 20px;
}
.infoMessageDiv{
    text-align: center;
    margin-top:35px;
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
.smallBottleImg{
    height: 130px;
}
.largeBottleImg{
    height: 220px;
}
.imgText{
    display: grid;
    font-variant: small-caps;
    font-size: 24px;
    color: #000000;
}
.div1{
    display: inline-block;
    width: 200px;
}
.addButtons{
    font-variant: small-caps;
    font-size: 25px;
    border-radius: 20px;
    background: honeydew;
}
.quantityTextBox{
    text-align: center;
    font-size: 20px;
    width: 143px;
}
.inc_decAmount{
    text-align: center;
    font-size: 20px;
    width: 143px;
}

.divGrid{
    display:inline-block;
    width: 360px;
}
.gvItems{
    font-size: 22px;
    background: #b1bcfe;
    margin-bottom: 28px;
}
td{
    text-align:center;
}
a{
    color: black;
    font-variant: small-caps;
}
.removeButton{

}


</style>

</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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


    <div id="div1" class="div1">

    <asp:Image ID="imgSmallTransparentBottle" CssClass="smallBottleImg" ImageUrl="~/Images/smallT.png" runat="server" />
    
    <asp:Label ID="lblSmallT" CssClass="imgText" runat="server" Text="Small Clear"></asp:Label>

    <asp:Label ID="lblAmount" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtSmallClearMls" class="inc_decAmount" min="0" max="15" step="1" value="0" required="required" /> 

    <asp:Button ID="btnAddSmallClear" CssClass="addButtons" runat="server" Text="Add Item" OnClick="btnAddSmallClear_Click" />

    </div>


    <div id="div2" class="div1">

    <asp:Image ID="imgSmallBlackBottle" CssClass="smallBottleImg"  ImageUrl="~/Images/smallB.png"  runat="server" />

    <asp:Label ID="lblSmallB" CssClass="imgText" runat="server" Text="Small Black"></asp:Label>

    <asp:Label ID="lblAmount2" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtSmallBlackMls" class="inc_decAmount" min="0" max="15" step="1" value="0" required="required" /> 

    <asp:Button ID="btnAddSmallBlack" CssClass="addButtons" runat="server" Text="Add Item" OnClick="btnAddSmallBlack_Click" />

    </div>


    <div id="div3" class="div1">

    <asp:Image ID="imgSmallRedBottle" CssClass="smallBottleImg" ImageUrl="~/Images/smallR.png" runat="server" />

    <asp:Label ID="lblSmallRed" CssClass="imgText" runat="server" Text="Small Red"></asp:Label>

    <asp:Label ID="lblAmount3" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtSmallRedMls" class="inc_decAmount" min="0" max="15" step="1" value="0" required="required" /> 

    <asp:Button ID="btnAddSmallRed" CssClass="addButtons" runat="server" Text="Add Item" OnClick="btnAddSmallRed_Click" />

    </div>


    <div id="div4" class="div1">

    <asp:Image ID="imgLargeTransparentBottle" CssClass="largeBottleImg" ImageUrl="~/Images/largeT.png" runat="server" />

    <asp:Label ID="lblLargeT" CssClass="imgText" runat="server" Text="Large Clear"></asp:Label>

    <asp:Label ID="lblAmount4" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtLargeClearMls" class="inc_decAmount" min="0" max="50" step="1" value="0" required="required" /> 

    <asp:Button ID="btnAddLargeClear" CssClass="addButtons" runat="server" ValidationGroup="largeIncDec1" Text="Add Item" OnClick="btnAddLargeClear_Click" />

    </div>


    <div id="divCartList" class="divGrid" runat="server">

    <asp:GridView 
    ID="gvItems" 
    CssClass="gvItems"
    runat="server"
    HorizontalAlign="Center"   
    DataKeyNames="ID" 
    OnRowCreated="gvItems_RowCreated"
    OnRowDeleting="gvItems_RowDeleting">

    <RowStyle BackColor="#e0d8d8" CssClass="Row"/>
    <Columns> <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/btnremove.png" DeleteText="remove" ItemStyle-CssClass="removeButton" ShowDeleteButton="true"  /></Columns>

    <AlternatingRowStyle
    CssClass="AltRow"
    VerticalAlign="Middle" 
    Wrap="True"
    BackColor="#f0f0f0" />

    </asp:GridView>

    <asp:Button ID="btnConfirmOrder" CssClass="navButton" runat="server" Text="Confirm Order" OnClick="btnConfirmOrder_Click" Visible="false" />

    </div>

    </div>

    <div id="infoMessageDiv" class="infoMessageDiv">

    <asp:Label ID="lblInfoMessage" CssClass="infoMessage" runat="server"></asp:Label>

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
    
   
</asp:Content>

