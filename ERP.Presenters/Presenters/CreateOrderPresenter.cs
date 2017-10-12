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
    }
}
