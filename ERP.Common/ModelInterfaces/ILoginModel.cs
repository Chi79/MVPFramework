using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface ILoginModel
    {

        bool CheckClientExists(string username, string password);

        int GetClientType();


    }
}
