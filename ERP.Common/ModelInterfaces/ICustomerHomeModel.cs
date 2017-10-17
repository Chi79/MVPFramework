using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.Enums;

namespace ERP.Common.ModelInterfaces
{
    public interface ICustomerHomeModel
    {

        string GetCurrentClientName();

        void ResetSession();

        bool CheckLoggedInStatus();

        void SetSelectedOrderIdToSession(int orderId);

        int GetSelectedOrderIdFromSession();

        IEnumerable<object> FetchOrderData(OrdersToFetch ordersToFetch);

        string FetchOrderDataInfoMessage(OrdersToFetch ordersToFetch);

        IEnumerable<object> FetchItemsData(ItemsToFetch itemsToFetch);

        string FetchItemDataInfoMessage(ItemsToFetch itemsToFetch);

    }
}
