using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.FetchDataInterfaces
{
    public interface IFetchOrderItemData
    {
        IEnumerable<object> FetchItemDataForOrder(int orderId);

        string InfoMessage { get; }
    }
}
