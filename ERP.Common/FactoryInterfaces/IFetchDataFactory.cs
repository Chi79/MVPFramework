using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.Enums;

namespace ERP.Common.FactoryInterfaces
{
    public interface IFetchDataFactory
    {

        IEnumerable<object> FetchDataForCustomer(OrdersToFetch ordersToFetch , string customerEmail);

        string FetchAdminOrderDataInfoMessage(OrdersToFetch ordersToFetch);

        IEnumerable<object> FetchDataForAdmin(OrdersToFetch ordersToFetch);

        string FetchOrderDataInfoMessage(OrdersToFetch ordersToFetch);

        IEnumerable<object> FetchOrderItemData(ItemsToFetch itemsToFetch, int orderId);

        string FetchItemDataInfoMessage(ItemsToFetch ordersToFetch);

        string FetchProductionData(DataToFetch dataToFetch);

    }
}
