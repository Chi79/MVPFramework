<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmOrderView.aspx.cs" Inherits="ERP.Views.ConfirmOrderView"  MasterPageFile="~/MasterView.Master"%>

<asp:Content ContentPlaceHolderID="head" runat="server">

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
    /*position:relative;
    font-size: 30px;
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
    background-image: -webkit-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -moz-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -ms-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -o-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: linear-gradient(to bottom, #A8B1BF, #CAB0D4);
    text-decoration: none;
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
    background-image: -webkit-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -moz-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -ms-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: -o-linear-gradient(top, #A8B1BF, #CAB0D4);
    background-image: linear-gradient(to bottom, #A8B1BF, #CAB0D4);
    text-decoration: none;
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
    border-radius: 16px;
    border:hidden;
}
td{
    text-align:center;
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

    <asp:Button ID="btnPlaceOrder" CssClass="navButton" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click"
                UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please Wait..';"  />

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
    
   
</asp:Content>
