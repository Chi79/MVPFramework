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

        string SmallClearAmountInMls { get; set; }

        string SmallBlackAmountInMls { get; set; }

        string SmallRedAmountInMls { get; set; }

        string LargeClearAmountInMls { get; set; }

        IEnumerable<object> SetDataSource { set; }

        void BindData();

        void DisableCartDiv();

        void EnableCartDiv();

        void RedirectToHomePage();

        void RedirectToLoginPage();

        event EventHandler<EventArgs> PageLoad;

        event EventHandler<EventArgs> ViewOrdersClick;

        event EventHandler<EventArgs> LogoutClick;

        event EventHandler<EventArgs> AddSmallClearClick;

        event EventHandler<EventArgs> AddSmallBlackClick;

        event EventHandler<EventArgs> AddSmallRedClick;

        event EventHandler<EventArgs> AddLargeClearClick;

        event EventHandler<int> DeleteItemClick;

    }
}
