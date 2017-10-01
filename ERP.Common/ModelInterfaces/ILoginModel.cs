using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface ILoginModel
    {

        void AttemptToLogin(string username, string password);

        bool IsLoginSuccesful();

        int GetClientType();


    }
}
