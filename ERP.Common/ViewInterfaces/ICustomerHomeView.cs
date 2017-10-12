using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface ICustomerHomeView
    {

        string Message { set; }

        bool MessageVisible { set; }

        IEnumerable<object> SetDataSource { set; }

        void BindData();

        object SelectedRowValueDataKey { get; }

        int SelectedRowIndex { get; }

        void RedirectToLoginPage();

        event EventHandler<EventArgs> RowSelected;
    
        event EventHandler<EventArgs> LogoutClick;

        event EventHandler<EventArgs> PageLoad;

        event EventHandler<EventArgs> ShowAllOrdersClick;

        event EventHandler<EventArgs> ShowAllConfirmedOrdersClick;

        event EventHandler<EventArgs> ShowAllOrdersInProductionClick;

        event EventHandler<EventArgs> ShowAllCompletedOrdersClick;

    }
}
