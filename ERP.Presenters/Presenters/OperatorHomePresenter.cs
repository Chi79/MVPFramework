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
    public class OperatorHomePresenter : PresenterBase
    {

        private readonly IOperatorHomeView _view;

        private readonly IOperatorHomeModel _model;


        public OperatorHomePresenter(IOperatorHomeView view , IOperatorHomeModel model)
        {

            _view = view;

            _model = model;

            WireUpEvents();
            
        }

        private void WireUpEvents()
        {

            _view.LogoutClick += OnLogoutClicked;

            _view.PageLoad += OnPageLoaded;

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool IsValid = _model.CheckLoggedInStatus();
            if (IsValid)
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
