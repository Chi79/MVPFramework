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
        AllCompleted
    }

    public enum ItemsToFetch
    {
        AllItemsInOrder
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
}
