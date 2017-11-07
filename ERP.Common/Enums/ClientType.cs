using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Enums
{
    public enum ClientType
    {
        Customer,
        Operator,
        Admin
    }
    public enum OrderStatus
    {
        Confirmed,
        InProduction,
        Complete
    }

    public enum OrdersToFetch
    {
        AllOrders,
        AllConfirmed,
        AllInProduction,
        AllCompleted,
        CurrentOrder,
        CurrentItem
    }

    public enum ItemsToFetch
    {
        AllItemsInOrder,
        AllItemsInOrderAdmin
    }

    public enum ItemStatus
    {
        Confirmed,
        InProduction,
        Complete,
        Failed
    }

    public enum ItemSize
    {
        Small,
        Large
    }

    public enum ItemColour
    {
        Clear,
        Black,
        Red
    }

    public enum DataToFetch
    {

        NumberOfItemsCompleted,
        NumberOfOrdersCompleted,
        NumberOfItemsFailed,
        AvgTimeToProduceAnItem

    }
}
