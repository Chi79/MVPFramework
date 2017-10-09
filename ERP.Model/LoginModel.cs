using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.Structs;
using ERP.DataTables.Tables;

namespace ERP.Model
{
    public class LoginModel : ILoginModel
    {
        private readonly IUnitOfWork _uOW;

        private LoginResponse loginResponse;

        public LoginModel(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public bool CheckClientExists(string username, string password)
        {

            loginResponse = _uOW.CLIENTs.LoginRequest(username, password);

            return loginResponse.CredentialsApproved;

        }
        
        public int GetClientType()
        {

            return loginResponse.ClientType;

        }

        public void InitializeSession()
        {

            //TODO Add session methods to store client to session and reset sessionstate when logging in

        }


    }
}
