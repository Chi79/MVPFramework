using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface IWelcomeModel
    {
        string GetWelcomeTitle();
        string GetWelcomeMessage();
    }
}
