<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHomeView.aspx.cs" EnableEventValidation="false" Inherits="ERP.Views.CustomerHomeView"  MasterPageFile="~/MasterView.Master"%>


<asp:Content  ContentPlaceHolderID="head" runat="server">

<title></title>

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
    /*position:relative;
    font-size: 45px;
    font-variant: small-caps;
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
    background-image: -webkit-linear-gradient(top, #ffffff, #8e8686);
    background-image: -moz-linear-gradient(top, #ffffff, #8e8686);
    background-image: -ms-linear-gradient(top, #ffffff, #8e8686);
    background-image: -o-linear-gradient(top, #ffffff, #8e8686);
    background-image: linear-gradient(to bottom, #ffffff, #8e8686);
    text-decoration: none;
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
    /*font-size: 32px;
    font-variant: small-caps;
    background: honeydew;
    border-radius: 14px;
    border-bottom-width: thick;
    margin-top: 25px;
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
    font-size: 33px;
    font-weight: 200;
    padding: 5px;
    box-shadow: 7px 1px 34px -6px #FFFFFF;
    -webkit-box-shadow: 7px 1px 34px -6px #FFFFFF;
    -moz-box-shadow:7px 1px 34px -6px #FFFFFF;
    text-shadow: 8px 0px 43px #000000;
    border: solid #FFFFFF 1px;
    text-decoration: none;
    display: inline-block;
    cursor: pointer;
    margin-top:6px;
}
.searchButtons:hover {
    background: #A8B1BF;
    background-image: -webkit-linear-gradient(top, #ffffff, #8e8686);
    background-image: -moz-linear-gradient(top, #ffffff, #8e8686);
    background-image: -ms-linear-gradient(top, #ffffff, #8e8686);
    background-image: -o-linear-gradient(top, #ffffff, #8e8686);
    background-image: linear-gradient(to bottom, #ffffff, #8e8686);
    text-decoration: none;
}
.divGrid{
    margin-top: 20px;
    overflow: auto;
    width:max-content;
    margin-left: auto;
    margin-right: auto;
    height: 300px;
}
.divGrid::-webkit-scrollbar {
    width: 1em;
}
 
.divGrid::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
}
 
.divGrid::-webkit-scrollbar-thumb {
    background-color: #504e4e;
    outline: 1px solid #2d3135;
}
.gvOrders{
    font-size: 40px;
    background: #b1bcfe;
    border-radius: 16px;
    border:hidden;
}
.Row td{
    text-align:center;
    cursor:pointer
}
.AltRow td{
    text-align:center;
    cursor:pointer
}
.Row:hover{
      border-color:#b1bcfe;
      cursor:pointer
}
.AltRow:hover{  
      border-color:#b1bcfe;
      cursor:pointer
}

</style>

</asp:Content>

<asp:Content  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        


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

    <asp:Label ID="lblInfoMessage" CssClass="infoMessage" runat="server"></asp:Label>


    <div id="searchButtonsDiv1" class="searchButtonsDiv1">

    <asp:Button ID="btnShowAllOrders" CssClass="searchButtons" runat="server" Text="Show All Orders" OnClick="btnShowAllOrders_Click"
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';"/>

    <asp:Button ID="btnShowAllConfirmedOrders" CssClass="searchButtons" runat="server" Text="Confirmed Orders" OnClick="btnShowAllConfirmedOrders_Click"
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';" />

    <asp:Button ID="btnShowAllOrdersInProduction" CssClass="searchButtons" runat="server" Text="Orders In Production" OnClick="btnShowAllOrdersInProduction_Click"
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';" />

    <asp:Button ID="btnShowAllCompletedOrders" CssClass="searchButtons" runat="server" Text="Completed Orders" OnClick="btnShowAllCompletedOrders_Click"
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';" />

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

</asp:Content>

