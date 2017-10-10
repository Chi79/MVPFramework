using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Presenters.Bases;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;

namespace ERP.Presenters.Presenters
{
    public class CustomerHomePresenter : PresenterBase
    {

        private readonly ICustomerHomeView _view;

        private readonly ICustomerHomeModel _model;


        public CustomerHomePresenter(ICustomerHomeView view, ICustomerHomeModel model)
        {

            _view = view;

            _model = model;

            _view.LogoutClick += OnLogoutClicked;

            _view.PageLoad += OnPageLoaded;


        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool? IsValid = _model.CheckLoggedInStatus();
            if ((bool)IsValid)
            {

                DisplaytWelcomeMessage();

            }
            else
            {

                _view.RedirectToLoginPage();

            }

        }

        public void DisplaytWelcomeMessage()
        {

            _view.MessageVisible = true;

            _view.Message = "Welcome " + _model.GetCurrentClientName();

        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {

            _model.ResetSession();

            _view.RedirectToLoginPage();

        }
    }
}
