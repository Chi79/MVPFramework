using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.RepositoryInterfaces;
using ERP.DataTables.Tables;
using ERP.Common.Enums;

namespace ERP.DataAccess.ConcreteRepositories
{
    public class OrdersRepository : Repository<ORDERS> , IOrdersRepository
    {

        public OrdersRepository(ERPContext context) : base(context)  // calls our base constructor Repository<CLIENT>
        {

        }

        public ERPContext ERPContext
        {

            get { return Context as ERPContext; }    // casting our context class as an entity DbContext 

        }


        public IEnumerable<ORDERS> GetAllOrders()
        {

            return ERPContext.ORDERS.OrderBy(o => o.OrderID);

        }

        public IEnumerable<ORDERS> GetAllOrdersForCustomerByEmail(string email)
        {

            var orders = ERPContext.ORDERS.Where(o => o.CLIENT.Email == email).OrderBy(o => o.OrderID);

            return orders;

        }

        public IEnumerable<ORDERS> GetAllOrdersForCustomerByEmailAndStatus(string email, int orderStatus)
        {

            var orders = GetAllOrdersForCustomerByEmail(email).ToList()
                        .Where(o => o.ORDERTRACKER.Any(ot => ot.OrderStatusID == orderStatus));

            return orders;

        }


        public ORDERS GetAnOrderByOrderId(int orderId)
        {

            return ERPContext.ORDERS.FirstOrDefault(o => o.OrderID.Equals(orderId));

        }


        public IEnumerable<ITEM> GetAllItems()
        {

            return ERPContext.ITEM.OrderBy(i => i.ItemID);

        }

        public IEnumerable<ITEM> GetAllItemsForCustomerByOrderId(int orderId)
        {
            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId).OrderBy(i => i.ItemID);

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsInProductionForCustomerByOrderId(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId).ToList()
                                       .Where(i => i.ITEMTRACKER.Any(it => it.ItemStatusID == (int)ItemStatus.InProduction));

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsCompletedForCustomerByOrderId(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId).ToList()
                                       .Where(i => i.ITEMTRACKER.Any(it => it.ItemStatusID == (int)ItemStatus.Complete));

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsFailedForCustomerByOrderId(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId).ToList()
                                       .Where(i => i.ITEMTRACKER.Any(it => it.ItemStatusID == (int)ItemStatus.Failed));

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsInProduction()
        {

            var items = ERPContext.ITEM.ToList()
                                       .Where(i => i.ITEMTRACKER.Any(it => it.ItemStatusID == (int)ItemStatus.InProduction));

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsCompleted()
        {

            var items = ERPContext.ITEM.ToList()
                                       .Where(i => i.ITEMTRACKER.Any(it => it.ItemStatusID == (int)ItemStatus.Complete));

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsFailed()
        {

            var items = ERPContext.ITEM.ToList()
                                       .Where(i => i.ITEMTRACKER.Any(it => it.ItemStatusID == (int)ItemStatus.Failed));

            return items;

        }

        public void InsertAllItemsToDB(IEnumerable<ITEM> allItems)
        {

            ERPContext.ITEM.AddRange(allItems);

        }

        public ITEM GetAnItemByItemId(int itemId)
        {

            return ERPContext.ITEM.FirstOrDefault(i => i.ItemID == itemId);

        }

        public void UpdateOrderTracker(ORDERTRACKER trackingInfo)
        {

            ERPContext.ORDERTRACKER.Add(trackingInfo);

        }

        public void UpdateItemTracker(ITEMTRACKER trackingInfo)
        {

            ERPContext.ITEMTRACKER.Add(trackingInfo);

        }
    }
}
