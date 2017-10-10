using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface IOperatorHomeModel
    {

        string GetCurrentClientName();

        void ResetSession();

        bool? CheckLoggedInStatus();

    }
}
