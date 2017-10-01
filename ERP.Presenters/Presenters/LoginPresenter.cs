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

        private ClientType _clientType;
        
        public LoginPresenter(ILoginView view, ILoginModel model)
        {

            _view = view;

            _model = model;

            _view.LoginAttempt += OnLoginAttempt;

        }

        private void OnLoginAttempt(object sender, EventArgs e)
        {

            AttemptLogin();

        }

        public void AttemptLogin()
        {

            string email = _view.Email;

            string password = _view.Password;

            _model.AttemptToLogin(email, password);


            bool LoginIsSuccesful = _model.IsLoginSuccesful();
            if(LoginIsSuccesful)
            {

                _clientType = (ClientType)_model.GetClientType();

                InitializeSession(email);

                CheckClientType();

            }
            else
            {

                _view.Message = "Login Failed";

            }
      
        }

        private void CheckClientType()
        {

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

        public void InitializeSession(string email)
        {
            //TODO store client details to session and reset session state
        }
    }
}
