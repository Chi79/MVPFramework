﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;
using ERP.Presenters.Bases;



namespace ERP.Presenters.Presenters
{
    public class ConfirmOrderPresenter : PresenterBase
    {

        private IConfirmOrderView _view;

        private IConfirmOrderModel _model;


        public ConfirmOrderPresenter(IConfirmOrderView view, IConfirmOrderModel model)
        {

            _view = view;

            _model = model;

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.PageLoad += OnPageLoaded;

            _view.LogoutClick += OnLogoutClicked;

            _view.EditOrderClick += OnEditOrderClicked;

            _view.OrderConfirmedClick += OnOrderConfirmedClicked;

            _view.ViewAllOrdersClick += OnViewAllOrdersClicked;

        }


        public void DisplayMessage()
        {

            _view.MessageVisible = true;

            _view.Message = "Order Confirmation Page For " + _model.GetCurrentClientName();

        }

        public override void FirstTimeInit()
        {

            base.FirstTimeInit();

            CheckIsNavigationValid();

            DisplayMessage();

            DisplayItemList();

        }

        private void CheckIsNavigationValid()
        {

            bool IsNotValid = _model.CheckIsNavigationValid() || _model.CheckForEmptyOrder();
            if(IsNotValid)
            {

                _view.RedirectToHomePage();

            }

        }

        private void DisplayItemList()
        {

            _view.PlaceOrderButtonVisible = true;

            _view.InfoMessage = string.Empty;

            _view.EnableCartDiv();

            _view.SetDataSource = _model.GetItemsInCart();

            _view.BindData();

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool IsValid = _model.CheckLoggedInStatus();
            if (!IsValid)
            {

                _view.RedirectToLoginPage();

            }

        }

        private void OnViewOrdersClicked(object sender, EventArgs e)
        {

            _view.RedirectToHomePage();

        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {

            _model.ResetSession();

            _view.RedirectToLoginPage();

        }

        private void OnViewAllOrdersClicked(object sender, EventArgs e)
        {

            _view.RedirectToHomePage();

        }


        private void OnEditOrderClicked(object sender, EventArgs e)
        {

            _view.RedirectToCreateOrderPage();

        }


        private void OnOrderConfirmedClicked(object sender, EventArgs e)
        {


            _view.PlaceOrderButtonVisible = false;

            _view.InfoMessage = _model.SaveConfirmedOrderToDB();

            _view.RedirectToOrderSuccessfulPage();

        }


    }
}
