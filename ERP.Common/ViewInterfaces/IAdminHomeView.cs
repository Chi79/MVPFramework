using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface IAdminHomeView
    {

        string Message { set; }

        bool MessageVisible { set; }

        string InfoMessage { set; }

        string NumberOfItemsProduced { set; }

        string NumberOfOrdersCompleted { set; }

        string NumberOfItemsFailed { set; }

        string AvgTimeToProduceAnItem { set; }

        IEnumerable<object> SetDataSource { set; }

        void BindData();

        object SelectedRowValueDataKey { get; }

        int SelectedRowIndex { get; }

        void RedirectToLoginPage();

        void RedirectToOrderPage();


        event EventHandler<EventArgs> RowSelected;

        event EventHandler<EventArgs> LogoutClick;

        event EventHandler<EventArgs> PageLoad;

        event EventHandler<EventArgs> ShowAllOrdersClick;

        event EventHandler<EventArgs> ShowAllConfirmedOrdersClick;

        event EventHandler<EventArgs> ShowAllOrdersInProductionClick;

        event EventHandler<EventArgs> ShowAllCompletedOrdersClick;

        event EventHandler<EventArgs> ShowCurrentOrderClick;

        event EventHandler<EventArgs> ShowCurrentItemClick;

        //event EventHandler<EventArgs> CreateNewOrderClick;

    }
}
