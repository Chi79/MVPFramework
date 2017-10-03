﻿using System;
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


            bool ClientExists = _model.CheckClientExists(_view.Email, _view.Password);
            if (ClientExists)
            {

               _clientType = (ClientType)_model.GetClientType();

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

    }
}