<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrderView.aspx.cs" Inherits="ERP.Views.CreateOrderView" MasterPageFile="~/MasterView.Master" %>



<asp:Content ContentPlaceHolderID="head" runat="server">


    <title></title>

    <style type="text/css">


     /*@media only screen and (min-device-width: 500px) and (max-device-width: 600px) and (orientation : landscape) 
     {
         .searchButtonsDiv1{
                          text-align:center;
                          width:20%
                          }
         .parent{
             height:20px;
             width:20%;
         }
         .searchButtonsDiv1{
             display:inline-block
         }
         .searchButtonsDiv0{
             display:inline-block
         }
         .childDiv0{
             display:inline-block
         }
         .childDiv1{
             display:inline-block
         }
         
     }*/


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
    margin-top: 5px;
}
.messageDiv{
    text-align: center;
    margin-top: 20px;
}
.infoMessageDiv{
    text-align: center;
    margin-top: 19px;
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
    /*position: fixed;*/
    display:inline-block;
    width: 100%;
    bottom:15px;
    margin-top:40px;
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
.smallBottleImg{
    height: 130px;
}
.largeBottleImg{
    height: 220px;
}
.imgText{
    display: grid;
    display:-ms-inline-grid;
    font-variant: small-caps;
    font-size: 24px;
    color: #000000;
}
.div1{
    display: inline-block;
    width: 200px;
}
.addButtons{
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
    font-size: 28px;
    font-weight: 200;
    padding: 18px;
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
.addButtons:hover{
    background: #A8B1BF;
    background-image: -webkit-linear-gradient(top, #ffffff, #8e8686);
    background-image: -moz-linear-gradient(top, #ffffff, #8e8686);
    background-image: -ms-linear-gradient(top, #ffffff, #8e8686);
    background-image: -o-linear-gradient(top, #ffffff, #8e8686);
    background-image: linear-gradient(to bottom, #ffffff, #8e8686);
    text-decoration: none;
}
.quantityTextBox{
    text-align: center;
    font-size: 20px;
    width: 143px;
}
.inc_decAmount{
    text-align: center;
    font-size: 26px;
    width: 143px;
    border-radius: 12px;
    margin-bottom: 5px;
    margin-top: 5px;
}

.divGrid{
    display:inline-block;
    width: 360px;
    margin-top: 25px;
}
.gvItems{
    font-size: 22px;
    background: #b1bcfe;
    margin-bottom: 28px;
    border-radius: 16px;
    border:hidden;
}
td{
    text-align:center;
}
a{
    color: black;
    font-variant: small-caps;
}
.removeButton{
    cursor:pointer
}


</style>

</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="parentDiv" class="parent" runat="server">

    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 

        <script type="text/javascript" > 

            $("#txtSmallClearMls").keyup(function () {
                $("#txtSmallClearMls").val(this.value.match(/[0-9]*/));
            });

            $("#txtSmallBlackMls").keyup(function () {
                $("#txtSmallBlackrMls").val(this.value.match(/[0-9]*/));
            });

            $("#txtSmallRedrMls").keyup(function () {
                $("#txtSmallRedMls").val(this.value.match(/[0-9]*/));
            });

            $("#txtLargeClearMls").keyup(function () {
                $("#txtLargeClearMls").val(this.value.match(/[0-9]*/));
            });

    </script>

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

    <input type="number" runat="server" id="txtSmallClearMls" class="inc_decAmount" min="0" max="12" step="1" value="0" required="required" inputmode="numeric" pattern="([0-9]{2})" /> 

    <asp:Button ID="btnAddSmallClear" CssClass="addButtons" runat="server" Text="Add Item" OnClick="btnAddSmallClear_Click" />

    </div>


    <div id="div2" class="div1">

    <asp:Image ID="imgSmallBlackBottle" CssClass="smallBottleImg"  ImageUrl="~/Images/smallB.png"  runat="server" />

    <asp:Label ID="lblSmallB" CssClass="imgText" runat="server" Text="Small Black"></asp:Label>

    <asp:Label ID="lblAmount2" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtSmallBlackMls" class="inc_decAmount" min="0" max="12" step="1" value="0" required="required" inputmode="numeric" pattern="([0-9]{2})"/> 

    <asp:Button ID="btnAddSmallBlack" CssClass="addButtons" runat="server" Text="Add Item" OnClick="btnAddSmallBlack_Click" />

    </div>


    <div id="div3" class="div1">

    <asp:Image ID="imgSmallRedBottle" CssClass="smallBottleImg" ImageUrl="~/Images/smallR.png" runat="server" />

    <asp:Label ID="lblSmallRed" CssClass="imgText" runat="server" Text="Small Red"></asp:Label>

    <asp:Label ID="lblAmount3" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtSmallRedMls" class="inc_decAmount" min="0" max="12" step="1" value="0" required="required" inputmode="numeric"  pattern="([0-9]{2})"/> 

    <asp:Button ID="btnAddSmallRed" CssClass="addButtons" runat="server" Text="Add Item" OnClick="btnAddSmallRed_Click" />

    </div>


    <div id="div4" class="div1">

    <asp:Image ID="imgLargeTransparentBottle" CssClass="largeBottleImg" ImageUrl="~/Images/largeT.png" runat="server" />

    <asp:Label ID="lblLargeT" CssClass="imgText" runat="server" Text="Large Clear"></asp:Label>

    <asp:Label ID="lblAmount4" CssClass="imgText" runat="server" Text="Amount (ml)"></asp:Label>

    <input type="number" runat="server" id="txtLargeClearMls" class="inc_decAmount" min="0" max="45" step="1" value="0" required="required" inputmode="numeric"  pattern="([0-9]{2})"/> 

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

