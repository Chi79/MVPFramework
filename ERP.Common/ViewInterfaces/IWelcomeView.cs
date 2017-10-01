using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface IWelcomeView
    {
        string WelcomeTitle { set; }
        string WelcomeMessage { set; }

    }
}
