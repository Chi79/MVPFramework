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

        private readonly ISessionService _session;

        private LoginResponse _loginResponse;


        public LoginModel(IUnitOfWork uOW, ISessionService session)
        {

            _uOW = uOW;

            _session = session;

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

        public int GetClientID()
        {

            return _uOW.CLIENTs.GetClientIDByEmail(_loginResponse.ClientEmail);

        }

        public void InitializeSession()
        {

            _session.CurrentClientEmail = _loginResponse.ClientEmail;

            _session.CurrentClientName = _loginResponse.ClientName;

            _session.CurrentClientID = GetClientID();

            _session.LoggedInStatus = true;

        }

    }
}
