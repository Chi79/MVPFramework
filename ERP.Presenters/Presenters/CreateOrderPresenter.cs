﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;
using ERP.Presenters.Bases;
using ERP.Common.Enums;

namespace ERP.Presenters.Presenters
{
    public class CreateOrderPresenter : PresenterBase
    {

        private readonly ICreateOrderView _view;

        private readonly ICreateOrderModel _model;


        public CreateOrderPresenter(ICreateOrderView view, ICreateOrderModel model)
        {

            _model = model;

            _view = view;

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.PageLoad += OnPageLoaded;

            _view.LogoutClick += OnLogoutClicked;

            _view.ViewOrdersClick += OnViewOrdersClicked;

            _view.AddSmallClearClick += OnAddSmallClearClicked;

            _view.AddSmallBlackClick += OnAddSmallBlackClicked;

            _view.AddSmallRedClick += OnAddSmallRedClicked;

            _view.AddLargeClearClick += OnAddLargeClearClicked;

            _model.CartFull += OnCartIsFilled;

            _model.ItemAddedToCart += OnItemAddedToCart;

            _model.ItemIsEmpty += OnBottleIsEmpty;

        }


        public void DisplayMessage()
        {

            _view.MessageVisible = true;

            _view.Message = "Create A New Order for " + _model.GetCurrentClientName();

        }

        public override void FirstTimeInit()
        {

            base.FirstTimeInit();

            DisplayMessage();

            _view.DisableCartDiv();

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool? IsValid = _model.CheckLoggedInStatus();
            if (!(bool)IsValid)
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


        private void OnAddSmallClearClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallClearAmountInMls;

            _model.AddItemToCart(amount, ItemType.Small_Clear);

            _view.SmallClearAmountInMls = "0";

            DisplayItemList();

        }

        private void OnAddSmallBlackClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallBlackAmountInMls;

            _model.AddItemToCart(amount, ItemType.Small_Black);

            _view.SmallBlackAmountInMls = "0";

            DisplayItemList();

        }


        private void OnAddSmallRedClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallRedAmountInMls;

            _model.AddItemToCart(amount, ItemType.Small_Red);

            _view.SmallRedAmountInMls = "0";

            DisplayItemList();

        }


        private void OnAddLargeClearClicked(object sender, EventArgs e)
        {

            string amount = _view.LargeClearAmountInMls;

            _model.AddItemToCart(amount, ItemType.Large_Clear);

            _view.LargeClearAmountInMls = "0";

            DisplayItemList();

        }

        private void DisplayItemList()
        {

            if(_model.GetItemsInCart().Count() != 0)
            {
                _view.EnableCartDiv();

                _view.SetDataSource = _model.GetItemsInCart();

                _view.BindData();
            }
            
        }


        private void OnCartIsFilled(object sender, string e)
        {

            _view.InfoMessage = e;

        }

        private void OnBottleIsEmpty(object sender, string e)
        {

            _view.InfoMessage = e;

        }

        private void OnItemAddedToCart(object sender, string e)
        {

            _view.InfoMessage = e;

        }

    }
}
