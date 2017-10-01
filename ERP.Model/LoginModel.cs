using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;

namespace ERP.Model
{
    public class LoginModel : ILoginModel
    {
        public void AttemptToLogin(string username, string password)
        {

            //TODO login against DB with OUW and LoginStruct

        }
        
        public bool IsLoginSuccesful()
        {

            return true; //TODO get data from LoginStruct

        }
        
        public int GetClientType()
        {

            return 0; //TODO get data from LoginStruct

        }

        //TODO Add session methods to store client to session and reset sessionstate
    }
}
