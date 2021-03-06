﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Common.ViewInterfaces;
using ERP.Presenters.Bases;
using ERP.Presenters.Presenters;

namespace ERP.Views
{
    public partial class CreateOrderView : ViewBase<CreateOrderPresenter> , ICreateOrderView
    {
        public string Message { set { lblMessage.Text = value; } }

        public bool MessageVisible { set { lblMessage.Visible = value; } }

        public bool ConfirmOrderButtonVisible { set {btnConfirmOrder.Visible = value; } }

        public string InfoMessage { set { lblInfoMessage.Text = value; } }

        public string SmallClearAmountInMls { get {return txtSmallClearMls.Value ; } set { txtSmallClearMls.Value = value ; }  }

        public string SmallBlackAmountInMls { get { return txtSmallBlackMls.Value; } set { txtSmallBlackMls.Value = value; } }

        public string SmallRedAmountInMls { get { return txtSmallRedMls.Value; } set { txtSmallRedMls.Value = value; } }

        public string LargeClearAmountInMls { get { return txtLargeClearMls.Value; } set { txtLargeClearMls.Value = value; } }

        public IEnumerable<object> SetDataSource { set { gvItems.DataSource = value; } }

        public void BindData()
        {

            gvItems.DataBind();

        }

        public void DisableCartDiv()
        {
    
            divCartList.Attributes.Add("style", "display:none");

        }

        public void EnableCartDiv()
        {

            divCartList.Attributes.Add("style", "display:inline-block");

        }

        public void RedirectToHomePage()
        { 
            Response.Redirect("CustomerHomeView.aspx");
        }


        public void RedirectToLoginPage()
        {
            Response.Redirect("LoginView.aspx");
        }

        public void RedirectToConfirmOrderPage()
        {

            Response.Redirect("ConfirmOrderView.aspx");

        }


        public event EventHandler<EventArgs> PageLoad;

        protected override void OnLoadComplete(EventArgs e)
        {

            base.OnLoadComplete(e);

            PageLoad?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ViewOrdersClick;

        protected void btnViewOrders_Click(object sender, EventArgs e)
        {

            ViewOrdersClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> LogoutClick;

        protected void btnLogoutButton_Click(object sender, EventArgs e)
        {

            LogoutClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> AddSmallClearClick;

        protected void btnAddSmallClear_Click(object sender, EventArgs e)
        {

            AddSmallClearClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> AddSmallBlackClick;

        protected void btnAddSmallBlack_Click(object sender, EventArgs e)
        {

            AddSmallBlackClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> AddSmallRedClick;

        protected void btnAddSmallRed_Click(object sender, EventArgs e)
        {

            AddSmallRedClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> AddLargeClearClick;

        protected void btnAddLargeClear_Click(object sender, EventArgs e)
        {

            AddLargeClearClick?.Invoke(this, EventArgs.Empty);

        }

        public event EventHandler<int> DeleteItemClick;

        protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int ID = (int)e.Keys[0];

            DeleteItemClick?.Invoke(this, ID);

        }

        public event EventHandler<EventArgs> ConfirmOrderClick;

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {

            ConfirmOrderClick?.Invoke(this, EventArgs.Empty);

        }

        protected void gvItems_RowCreated(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[1].Visible = false;

        }

    }
}
