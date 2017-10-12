using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Presenters.Bases;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;
using ERP.Common.Enums;

namespace ERP.Presenters.Presenters
{
    public class LoginPresenter : PresenterBase
    {

        private readonly ILoginView _view;

        private readonly ILoginModel _model;

        
        public LoginPresenter(ILoginView view, ILoginModel model)
        {

            _view = view;

            _model = model;

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.LoginClick += OnLoginClicked;

        }

        private void OnLoginClicked(object sender, EventArgs e)
        {

            bool ClientExists = _model.CheckClientExists(_view.Email, _view.Password);
            if (ClientExists)
            {

                CompleteLogin();

            }
            else
            {

                _view.MessageVisible = true;

                _view.Message = "Login Failed Please Enter A Valid Username & Password";

            }          

        }

        public void CompleteLogin()
        {

            _model.InitializeSession();           

            RedirectClient();

        }

        private void RedirectClient()
        {

            var _clientType = (ClientType)_model.GetClientType();

            switch (_clientType)
            {

                case ClientType.Customer:
                    _view.RedirectToCustomerHomePage();
                    break;
                case ClientType.Operator:
                    _view.RedirectToOperatorHomePage();
                    break;
                case ClientType.Admin:
                    _view.RedirectToAdminHomePage();
                    break;

            }

        }

    }
}
