using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.Structs;
using ERP.Common.ServiceInterfaces;

namespace ERP.Model
{
    public class LoginModel : ILoginModel
    {

        private readonly IUnitOfWork _uOW;

        private readonly ISessionService _sessionService;

        private LoginResponse _loginResponse;


        public LoginModel(IUnitOfWork uOW, ISessionService sessionservice)
        {

            _uOW = uOW;

            _sessionService = sessionservice;

        }

        public bool CheckClientExists(string username, string password)
        {

            _loginResponse = _uOW.CLIENTs.LoginRequest(username, password);

            return _loginResponse.CredentialsApproved;

        }
        
        public int GetClientType()
        {

            return _loginResponse.ClientType;

        }

        public void InitializeSession()
        {

            _sessionService.CurrentClientEmail = _loginResponse.ClientEmail;

            _sessionService.LoggedInStatus = true;

        }

    }
}
