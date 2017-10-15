using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface IConfirmOrderView
    {
        string Message { set; }

        bool MessageVisible { set; }

        string InfoMessage { set; }

        bool PlaceOrderButtonVisible { set; }

        IEnumerable<object> SetDataSource { set; }

        void BindData();

        void DisableCartDiv();

        void EnableCartDiv();

        void RedirectToHomePage();

        void RedirectToLoginPage();

        void RedirectToCreateOrderPage();

        event EventHandler<EventArgs> PageLoad;

        event EventHandler<EventArgs> EditOrderClick;

        event EventHandler<EventArgs> LogoutClick;

        event EventHandler<EventArgs> OrderConfirmedClick;

        event EventHandler<EventArgs> ViewAllOrdersClick;

    }
}
