using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;
using ERP.Presenters.Bases;



namespace ERP.Presenters.Presenters
{
    public class OrderSuccessfulPresenter : PresenterBase
    {

        private IOrderSuccessfulView _view;

        private IOrderSuccessfulModel _model;


        public OrderSuccessfulPresenter(IOrderSuccessfulView view, IOrderSuccessfulModel model)
        {

            _view = view;

            _model = model;

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.PageLoad += OnPageLoaded;

            _view.LogoutClick += OnLogoutClicked;

            _view.CreateNewOrderClick += OnCreateNewOrderClick;

            _view.ViewAllOrdersClick += OnViewAllOrdersClicked;

        }


        public void DisplayMessage()
        {

            _view.MessageVisible = true;

            _view.Message = "Thank you " + _model.GetCurrentClientName() + " For Your Order! </br> An Invoice has been sent to your email.";

        }

        public override void FirstTimeInit()
        {

            OnPageLoaded(this, EventArgs.Empty);

            base.FirstTimeInit();

            DisplayMessage();

            DisplayItemList();

        }

        private void DisplayItemList()
        {

            _view.InfoMessage = "Your Order Has Been Placed And Will Be Delivered Shortly!";

            _view.EnableCartDiv();

            _view.SetDataSource = _model.GetLastOrder();

            _view.BindData();

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool IsValid = (bool)_model.CheckLoggedInStatus();
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

        private void OnCreateNewOrderClick(object sender, EventArgs e)
        {

            _view.RedirectToCreateOrderPage();

        }


    }
}
