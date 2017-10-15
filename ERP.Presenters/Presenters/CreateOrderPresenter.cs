using System;
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

            _view.DeleteItemClick += OnDeleteItemClicked;

            _view.ConfirmOrderClick += OnConfirmOrderClicked;

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

            //_view.DisableCartDiv();
            DisplayItemList();

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

        private void OnDeleteItemClicked(object sender, int e)
        {

            int ID = e;

            _model.RemoveItemFromCart(ID);

            DisplayItemList();

        }

        private void OnAddSmallClearClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallClearAmountInMls;

            _model.AddItemToCart(ItemSize.Small, ItemColour.Clear, amount);

            _view.SmallClearAmountInMls = "0";

            DisplayItemList();

        }

        private void OnAddSmallBlackClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallBlackAmountInMls;

            _model.AddItemToCart(ItemSize.Small, ItemColour.Black, amount);

            _view.SmallBlackAmountInMls = "0";

            DisplayItemList();

        }


        private void OnAddSmallRedClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallRedAmountInMls;

            _model.AddItemToCart(ItemSize.Small, ItemColour.Red, amount);

            _view.SmallRedAmountInMls = "0";

            DisplayItemList();

        }


        private void OnAddLargeClearClicked(object sender, EventArgs e)
        {

            string amount = _view.LargeClearAmountInMls;

            _model.AddItemToCart(ItemSize.Large, ItemColour.Clear, amount);

            _view.LargeClearAmountInMls = "0";

            DisplayItemList();

        }

        private void OnConfirmOrderClicked(object sender, EventArgs e)
        {

            _view.RedirectToConfirmOrderPage();

        }

        private void DisplayItemList()
        {

            bool CartIsEmpty = _model.GetItemsInCart().Count() == 0;
            if (CartIsEmpty)
            {

                _view.DisableCartDiv();

                _view.ConfirmOrderButtonVisible = false;   
                     
            }
            else
            {
                _view.EnableCartDiv();

                _view.ConfirmOrderButtonVisible = true;

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
