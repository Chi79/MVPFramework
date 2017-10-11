using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DataTables.Tables;
using ERP.Common.Structs;

namespace ERP.Common.RepositoryInterfaces
{
    public interface IOrdersRepository : IRepository<ORDERS>
    {

        IEnumerable<ORDERS> GetAllOrders();

        IEnumerable<ORDERS> GetAllOrdersForCustomerByEmail(string email);

        IEnumerable<ORDERS> GetAllOrdersForCustomerByEmailAndStatus(string email, int orderStatus);

        ORDERS GetAnOrderByOrderId(int orderId);



        IEnumerable<ITEM> GetAllItems();

        IEnumerable<ITEM> GetAllItemsForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsInProductionForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsCompletedForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsFailedForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsInProduction();

        IEnumerable<ITEM> GetAllItemsCompleted();

        IEnumerable<ITEM> GetAllItemsFailed();

        ITEM GetAnItemByItemId(int itemId);

    }
}
