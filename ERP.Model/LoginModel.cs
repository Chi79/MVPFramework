using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.DataTables.Tables;

namespace ERP.Model
{
    public class LoginModel : ILoginModel
    {
        private readonly IUnitOfWork _uOW;

        public LoginModel(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public bool CheckClientExists(string username, string password)
        {

            return true; //TODO login against DB with OUW and LoginStruct

        }
        
        public int GetClientType()
        {

            return 0; //TODO get data from LoginStruct

        }

        //TODO Add session methods to store client to session and reset sessionstate when logging in
    }
}
