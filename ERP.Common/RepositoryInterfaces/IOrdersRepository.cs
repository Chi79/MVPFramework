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

        IEnumerable<object> GetAllOrdersAsObject();

        IEnumerable<ORDERS> GetAllOrdersNotCompleted();

        IEnumerable<ORDERS> GetAllOrdersCompleted();

        IEnumerable<ORDERS> GetAllOrdersInProductionButNotCompleted();

        IEnumerable<object> GetAllOrdersInProductionAsObject();

        IEnumerable<object> GetAllConfirmedOrdersAsObject();

        IEnumerable<ORDERS> GetAllOrdersNotInProductionAndNotCompleted();

        IEnumerable<ORDERS> GetAllOrdersForCustomerByEmail(string email);

        IEnumerable<object> GetAllOrdersForCustomerByEmailAsObject(string email);

        IEnumerable<ORDERS> GetAllOrdersForCustomerByEmailAndStatus(string email, int orderStatus);

        IEnumerable<object> GetAllOrdersForCustomerByEmailAndStatusAsObject(string email, int orderStatus);

        IEnumerable<object> GetAllOrdersByStatusAsObject(int orderStatus);

        IEnumerable<object> GetAllOrdersForCustomerInProductionAsObject(string email);

        IEnumerable<object> GetAllConfirmedOrdersForCustomerAsObject(string email);

        ORDERS GetAnOrderByOrderId(int orderId);

        bool IsOrderCompleteByOrderId(int orderId);

        ORDERS GetFirstOrderNotInProductionAndNotCompleted();

        ORDERS GetFirstOrderInProductionAndNotCompleted();

        IEnumerable<ORDERS> GetFirstOrderNotInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ORDERS> GetFirstOrderInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ORDERS> GetCurrentOrderToBeCompleted();

        void InsertAllItemsToDB(IEnumerable<ITEM> allItems);

        IEnumerable<ITEM> GetAllItems();

        IEnumerable<ITEM> GetAllItemsFromFirstOrderNotInProductionAndNotCompleted();

        IEnumerable<ITEM> GetAllItemsFromFirstOrderFailedOrNotInProductionAndNotCompleted();

        IEnumerable<ITEM> GetAllItemsInProductionButNotCompletedFromFirstOrderInProductionAndNotCompleted();

        IEnumerable<ITEM> GetFirstItemInProductionButNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

        IEnumerable<ITEM> GetFirstItemNotInProductionAndNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

        IEnumerable<object> GetFirstItemFailedOrNotInProductionFromCurrentOrderAsEnumerable();

        IEnumerable<ITEM> GetAllItemsForCustomerByOrderId(int orderId);

        IEnumerable<object> GetAllItemsForCustomerByOrderIdAsObject(int orderId);

        IEnumerable<ITEM> GetAllItemsInProductionForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsCompletedForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsFailedForCustomerByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItemsInProduction();

        IEnumerable<ITEM> GetAllItemsCompleted();

        IEnumerable<ITEM> GetAllItemsFailed();

        ITEM GetAnItemByItemId(int itemId);

        void UpdateOrderTracker(ORDERTRACKER trackingInfo);

        void UpdateItemTracker(ITEMTRACKER trackingInfo);

        string GetNumberOfCompleteOrders();

        string GetAvgTimeToProduceAnItem();

        string GetNumberOfFailedItems();

        string GetNumberOfCompleteItems();

    }
}
