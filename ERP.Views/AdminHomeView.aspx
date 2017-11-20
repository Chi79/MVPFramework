<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomeView.aspx.cs" EnableEventValidation="false" Inherits="ERP.Views.AdminHomeView" MasterPageFile="~/MasterView.Master" %>


<asp:Content  ContentPlaceHolderID="head" runat="server">

<title></title>

<style type="text/css">

body{
    color: #253131;
    background: #E6DADA; 
    background: -webkit-linear-gradient(to right, #274046, #E6DADA); 
    background: linear-gradient(to right, #274046, #E6DADA); 
}
form1{
    color:#253131;
}
.parent{
    width: 100%;
    height: 500px;
    background: #E6DADA; 
    background: -webkit-linear-gradient(to right, #274046, #E6DADA); 
    background: linear-gradient(to right, #274046, #E6DADA); 
    margin: auto;
    margin-top: 10px;
}
.messageDiv{
    text-align: center;
}
.message{
    font-variant: small-caps;
    font-size: 40px;
    color: #000000;
    font-weight:900;
}
.infoMessage{
    font-variant: small-caps;
    font-size: 30px;
    color: #000000;
    background: whitesmoke;
    border-radius: 11px;
}
.childDiv0{
    /*position: fixed;*/
    display:inline-block;
    width: 100%;
    bottom:15px;
    margin-top:20px;
}
.childDiv1{
    text-align: center;
}
.navButton{
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
    padding: 20px;
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
.pdfButton{
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
    font-size: 17px;
    font-weight: 200;
    padding: 4px;
    width: 178px;
    box-shadow: 7px 1px 34px -6px #FFFFFF;
    -webkit-box-shadow: 7px 1px 34px -6px #FFFFFF;
    -moz-box-shadow: 7px 1px 34px -6px #FFFFFF;
    text-shadow: 8px 0px 43px #000000;
    border: solid #FFFFFF 1px;
    text-decoration: none;
    display: inline-block;
    cursor: pointer;
}
.pdfButton:hover {
    background: #A8B1BF;
    background-image: -webkit-linear-gradient(top, #ffffff, #8e8686);
    background-image: -moz-linear-gradient(top, #ffffff, #8e8686);
    background-image: -ms-linear-gradient(top, #ffffff, #8e8686);
    background-image: -o-linear-gradient(top, #ffffff, #8e8686);
    background-image: linear-gradient(to bottom, #ffffff, #8e8686);
    text-decoration: none;
}
.searchButtonsDiv0{
    display:inline-block;
    /*position:fixed;*/
    width:100%;
    top:130px;
}
.searchButtonsDiv1{
    text-align:center;
    margin-top: 20px;
}
.searchButtons{
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
.statButtons{
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
.statButtons :hover{
    background: #A8B1BF;
    background-image: -webkit-linear-gradient(top, #ffffff, #8e8686);
    background-image: -moz-linear-gradient(top, #ffffff, #8e8686);
    background-image: -ms-linear-gradient(top, #ffffff, #8e8686);
    background-image: -o-linear-gradient(top, #ffffff, #8e8686);
    background-image: linear-gradient(to bottom, #ffffff, #8e8686);
    text-decoration: none;
}
.divGrid{
    margin-top: 10px;
    overflow: auto;
    width:max-content;
    margin-left: auto;
    margin-right: auto;
    height: 250px;
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
.TextBox{
    font-size: 27px;
    display: inline-block;
    text-align: center;
    width: 114px;
    border-radius: 12px;
    color: black;
}
.Label{
    font-size: 22px;
    color: black;
    font-variant: small-caps;
    font-weight: 900;
}
.LabelRight{
    font-size: 22px;
    color: black;
    font-variant: small-caps;
    font-weight: 900;
}
.DivTextBoxes{
    text-align: center;
    margin-top: 15px;
    margin-bottom: -10px;
}

.bottomButtons{
    display:inline-block;
}
.divLeft{
    margin-left: -70px;
}
.divRight{
    margin-left: -24px;
}
.pdfDiv{
    text-align:center;
}

</style>

</asp:Content>

<asp:Content  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        


    <div id="parentDiv" class="parent" runat="server">


    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 

    <asp:UpdatePanel runat="server"> 

    <Triggers>
        <asp:PostBackTrigger ControlID="btnGetPDF"/>
    </Triggers>

    <ContentTemplate>

    <div id="messageDiv" class="messageDiv">

    <asp:Label ID="lblMessage" CssClass="message" runat="server" Visible="false"></asp:Label>

    <div id="pdfDiv" class="pdfDiv">
    <asp:Button ID="btnGetPDF" CssClass="pdfButton" runat="server" Text="Download as PDF" OnClick="btnGetPDF_Click" Visible="True" />
    </div>

    </div>

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

    <div id="centralDiv" class="CentralDiv ">

    <div id="textboxesLeft" class="DivTextBoxes">

    <div class="divLeft">

    <asp:label ID="lblNumberOfCompletedItems" runat="server" CssClass="Label" Text="Completed Items :">

        <input id="txtNumberOfCompletedItems" runat="server" class="TextBox" type="number" disabled="disabled"/>

    </asp:label>

    

    <asp:label ID="lblNumberOfCompletedOrders" runat="server" CssClass="Label" Text="Completed Orders :">

         <input id="txtNumberOfCompletedOrders" runat="server" class="TextBox" type="number" disabled="disabled"/>

    </asp:label>

    </div>

    <div class="divRight">

    <asp:label ID="lblNumberOfFailedItems" runat="server" CssClass="Label" Text="Failed Items :">

    <input id="txtNumberOfFailedItems" runat="server" class="TextBox" type="number" disabled="disabled"/>

    </asp:label>

    

    <asp:label ID="lblAvgOrderProductionTime" runat="server" CssClass="Label" Text="Latest Order Time :">

    <input id="txtAvgOrderProductionTime" runat="server" class="TextBox" type="text" disabled="disabled"/>
         
    </asp:label>
  

    </div>

    </div>

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

    <asp:UpdatePanel runat="server" RenderMode="Inline">
        <ContentTemplate>

            <asp:Button ID="btnCurrentOrder" CssClass="navButton" runat="server" Text="Current Order" OnClick="btnCurrentOrder_Click" 
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';" />

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Button ID="btnLogoutButton" CssClass="navButton" runat="server" Text="Logout" OnClick="btnLogoutButton_Click" />

    <asp:UpdatePanel runat="server" RenderMode="Inline">
        <ContentTemplate>

    <asp:Button ID="btnCurrentItem" CssClass="navButton" runat="server" Text="Current Items" OnClick="btnCurrentItem_Click" 
                 UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';" />

      </ContentTemplate>
    </asp:UpdatePanel>

    </div>

    </div>

    </div>


</asp:Content>
