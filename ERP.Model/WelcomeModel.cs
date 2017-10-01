using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;

namespace ERP.Model
{
    public class WelcomeModel : IWelcomeModel
    {
        public string GetWelcomeTitle()
        {

            return "Festo ERP";

        }

        public string GetWelcomeMessage()
        {

            return "Welcome to the Festo ERP!";

        }

    }
}
