using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface ICustomerHomeModel
    {

        string GetCurrentClientName();

        void ResetSession();

        bool? CheckLoggedInStatus();

        void SetSelectedOrderIdToSession(int orderId);

        int GetSelectedOrderIdFromSession();

        IEnumerable<object> GetAllOrders();

        IEnumerable<object> GetAllConfirmedOrders();

        IEnumerable<object> GetAllOrdersInProduction();

        IEnumerable<object> GetAllCompletedOrders();

        IEnumerable<object> GetAllItemsForOrder(int orderId);
    }
}
