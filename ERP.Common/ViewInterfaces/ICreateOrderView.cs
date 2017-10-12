using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface ICreateOrderView
    {
        string Message { set; }

        bool MessageVisible { set; }

        string InfoMessage { set; }

        void RedirectToHomePage();

        void RedirectToLoginPage();

        event EventHandler<EventArgs> PageLoad;

        event EventHandler<EventArgs> ViewOrdersClick;

        event EventHandler<EventArgs> LogoutClick;
    }
}
