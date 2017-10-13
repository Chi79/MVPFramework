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

    public enum ItemStatus
    {
        Confirmed,
        InProduction,
        Complete,
        Failed
    }

    public enum ItemType
    {
        Small_Clear,
        Small_Black,
        Small_Red,
        Large_Clear
    }
}
