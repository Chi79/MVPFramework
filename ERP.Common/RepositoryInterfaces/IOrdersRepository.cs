using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DataTables.Tables;

namespace ERP.Common.RepositoryInterfaces
{
    public interface IOrdersRepository : IRepository<ORDERS>
    {

        IEnumerable<ORDERS> GetAllOrders();

        IEnumerable<ORDERS> GetAllOrdersNotCompleted();

        IEnumerable<ORDERS> GetAllOrdersInProductionButNotCompleted();

        IEnumerable<ORDERS> GetAllOrdersNotInProductionAndNotCompleted();

        IEnumerable<ORDERS> GetAllOrdersForCustomerByEmail(string email);

        IEnumerable<object> GetAllOrdersForCustomerByEmailWithHiddenFields(string email);

        IEnumerable<ORDERS> GetAllOrdersForCustomerByEmailAndStatus(string email, int orderStatus);

        IEnumerable<object> GetAllOrdersForCustomerByEmailAndStatusWithHiddenFields(string email, int orderStatus);

        ORDERS GetAnOrderByOrderId(int orderId);

        ORDERS GetFirstOrderNotInProductionAndNotCompleted();

        ORDERS GetFirstOrderInProductionAndNotCompleted();

        IEnumerable<ORDERS> GetFirstOrderNotInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ORDERS> GetFirstOrderInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ORDERS> GetCurrentOrderToBeCompleted();

        void InsertAllItemsToDB(IEnumerable<ITEM> allItems);

        IEnumerable<ITEM> GetAllItems();

        IEnumerable<ITEM> GetAllItemsFromFirstOrderNotInProductionAndNotCompleted();

        IEnumerable<ITEM> GetAllItemsInProductionButNotCompletedFromFirstOrderInProductionAndNotCompleted();

        IEnumerable<ITEM> GetFirstItemInProductionButNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ITEM> GetFirstItemNotInProductionAndNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ITEM> GetAllItemsForCustomerByOrderId(int orderId);

        IEnumerable<object> GetAllItemsForCustomerByOrderIdWithHiddenFields(int orderId);

        IEnumerable<ITEM> GetAllItemsInProductionForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsCompletedForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsFailedForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsInProduction();

        IEnumerable<ITEM> GetAllItemsCompleted();

        IEnumerable<ITEM> GetAllItemsFailed();

        ITEM GetAnItemByItemId(int itemId);

        void UpdateOrderTracker(ORDERTRACKER trackingInfo);

        void UpdateItemTracker(ITEMTRACKER trackingInfo);

    }
}
