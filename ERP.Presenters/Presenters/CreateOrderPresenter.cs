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

        }


        public void DisplayMessage()
        {

            _view.MessageVisible = true;

            _view.Message = "Create A New Order for " + _model.GetCurrentClientName();

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool? IsValid = _model.CheckLoggedInStatus();
            if ((bool)IsValid)
            {

                DisplayMessage();

            }
            else
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

            _view.InfoMessage = _model.AddItemToCart(amount , ItemType.Small_Clear);

            _view.SmallClearAmountInMls = "0";

            //get current cart items from session via model and display in view.

        }

        private void OnAddSmallBlackClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallBlackAmountInMls;

            _view.InfoMessage = _model.AddItemToCart(amount, ItemType.Small_Black);

            _view.SmallBlackAmountInMls = "0";

            //get current cart items from session via model and display in view.

        }


        private void OnAddSmallRedClicked(object sender, EventArgs e)
        {

            string amount = _view.SmallRedAmountInMls;

            _view.InfoMessage = _model.AddItemToCart(amount , ItemType.Small_Red );

            _view.SmallRedAmountInMls = "0";

            //get current cart items from session via model and display in view.

        }


        private void OnAddLargeClearClicked(object sender, EventArgs e)
        {

            string amount = _view.LargeClearAmountInMls;

            _view.InfoMessage = _model.AddItemToCart(amount, ItemType.Large_Clear);

            _view.LargeClearAmountInMls = "0";

            //get current cart items from session via model and display in view.

        }

    }
}
