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
    public class OrdersRepository : Repository<ORDERS>, IOrdersRepository
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

        public IEnumerable<object> GetAllOrdersAsObject()
        {

            return ERPContext.ORDERS.OrderBy(o => o.OrderID);

        }

        public IEnumerable<ORDERS> GetAllOrdersInProductionButNotCompleted()
        {

            //ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction)));

            return ordersList;

        }

        public IEnumerable<object> GetAllOrdersInProductionAsObject()
        {

            //ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction)));

            return ordersList;

        }

        public IEnumerable<object> GetAllConfirmedOrdersAsObject()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            IEnumerable<object> ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus == (int)OrderStatus.Confirmed)
                                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus != (int)OrderStatus.InProduction))
                                                                .ToList();

            return ordersList;

        }

        public IEnumerable<object> GetAllOrdersByStatusAsObject(int orderStatus)
        {

            var orders = GetAllOrders() as IQueryable<ORDERS>;

            IEnumerable<object> ordersList = orders.Where(o => o.ORDERTRACKER.Any(ot => ot.OrderStatus == orderStatus))
                                                                          .Select(otr => new { otr.OrderID, otr.OrderPrice });

            return ordersList;

        }

        public IEnumerable<ORDERS> GetAllOrdersNotCompleted()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete));

            return ordersList;

        }

        public IEnumerable<ORDERS> GetAllOrdersCompleted()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.Any(ot => ot.OrderStatus == (int)OrderStatus.Complete));

            return ordersList;

        }

        public IEnumerable<ORDERS> GetAllOrdersNotInProductionAndNotCompleted()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete && ot.OrderStatus
                                                                                       != (int)OrderStatus.InProduction));

            return ordersList;

        }

        public ORDERS GetFirstOrderNotInProductionAndNotCompleted()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete && ot.OrderStatus
                                                                                       != (int)OrderStatus.InProduction)).First();

            return firstOrder;

        }

        public ORDERS GetFirstOrderInProductionAndNotCompleted()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction))).FirstOrDefault();

            return firstOrder;

        }

        public IEnumerable<object> GetCurrentOrderInProduction()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction))).FirstOrDefault();

            if (firstOrder != null)
            {

                return new[] { firstOrder };

            }
            else
            {
                return null;
            }            

        }

        public bool IsOrderCompleteByOrderId(int orderId)
        {

            bool IsComplete = ERPContext.ORDERS.Any(o => o.OrderID == orderId &&
                                                         o.ORDERTRACKER.Any(ot => ot.OrderStatus == (int)OrderStatus.Complete));

            return IsComplete;

        }


        public IEnumerable<ORDERS> GetFirstOrderNotInProductionAndNotCompletedAsEnumerable()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete && ot.OrderStatus
                                                                                       != (int)OrderStatus.InProduction)).First();

            return new[] { firstOrder };

        }

        public IEnumerable<ORDERS> GetFirstOrderInProductionAndNotCompletedAsEnumerable()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction)))
                                                .FirstOrDefault();

            if (firstOrder == null)
            {
                return null;
            }
            else
            {
                return new[] { firstOrder };
            }

        }

        public IEnumerable<ORDERS> GetCurrentOrderToBeCompleted()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var firstOrder = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction)))
                                                .FirstOrDefault();

            if (firstOrder == null)
            {
                return null;
            }
            else
            {
                return new[] { firstOrder };
            }

        }

        public IEnumerable<ORDERS> GetAllOrdersForCustomerByEmail(string email)
        {

            var orders = ERPContext.ORDERS.Where(o => o.CLIENT.Email == email).OrderBy(o => o.OrderID);

            return orders;

        }

        public IEnumerable<object> GetAllOrdersForCustomerByEmailAsObject(string email)
        {

            var orders = ERPContext.ORDERS.Where(o => o.CLIENT.Email == email).OrderBy(o => o.OrderID)
                                                                              .Select(or => new { or.OrderID, or.OrderPrice });

            return orders;

        }

        public IEnumerable<ORDERS> GetAllOrdersForCustomerByEmailAndStatus(string email, int orderStatus)
        {

            var orders = GetAllOrdersForCustomerByEmail(email) as IQueryable<ORDERS>;

            IEnumerable<ORDERS> ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus == orderStatus));

            return ordersList;

        }

        public IEnumerable<object> GetAllOrdersForCustomerByEmailAndStatusAsObject(string email, int orderStatus)
        {

            var orders = GetAllOrdersForCustomerByEmail(email) as IQueryable<ORDERS>;

            IEnumerable<object> ordersList = orders.Where(o => o.ORDERTRACKER.Any(ot => ot.OrderStatus == orderStatus))
                                                                          .Select(otr => new { otr.OrderID, otr.OrderPrice });

            return ordersList;

        }

        public IEnumerable<object> GetAllOrdersForCustomerInProductionAsObject(string email)
        {

            var orders = GetAllOrdersForCustomerByEmail(email) as IQueryable<ORDERS>;

            IEnumerable<object> ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete)
                                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction))
                                                                .Select(otr => new { otr.OrderID, otr.OrderPrice }).ToList();
            return ordersList;

        }

        public IEnumerable<object> GetAllConfirmedOrdersForCustomerAsObject(string email)
        {

            var orders = GetAllOrdersForCustomerByEmail(email) as IQueryable<ORDERS>;

            IEnumerable<object> ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus == (int)OrderStatus.Confirmed)
                                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus != (int)OrderStatus.InProduction))
                                                                .Select(otr => new { otr.OrderID, otr.OrderPrice }).ToList();

            return ordersList;

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

        public IEnumerable<object> GetAllItemsForCustomerByOrderIdAsObject(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId).OrderBy(i => i.ItemID);

            return items;

        }

        public IEnumerable<ITEM> GetAllItemsFromFirstOrderNotInProductionAndNotCompleted()
        {

            var firstOrder = GetFirstOrderNotInProductionAndNotCompleted();

            var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID).OrderBy(i => i.ItemID);

            var itemsList = items.Where(i => i.ITEMTRACKER.All(it => it.ItemStatus != (int)ItemStatus.Complete
                                                                  && it.ItemStatus != (int)ItemStatus.InProduction)).ToList();

            return itemsList;

        }

        public IEnumerable<ITEM> GetAllItemsInProductionButNotCompletedFromFirstOrderInProductionAndNotCompleted()
        {

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            if (firstOrder != null)
            {

                ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

                IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.All(it => it.ItemStatus != (int)ItemStatus.Complete)
                                                           && i.ITEMTRACKER.Any(it2 => it2.ItemStatus == (int)ItemStatus.InProduction)).ToList();
                return itemList;

            }
            else
            {
                return null;
            }

        }

        public IEnumerable<ITEM> GetFirstItemInProductionButNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable()
        {

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            if (firstOrder != null)
            {

                ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

                var firstItem = items.Where(i => i.ITEMTRACKER.All(it => it.ItemStatus != (int)ItemStatus.Complete)
                                                           && i.ITEMTRACKER.Any(it2 => it2.ItemStatus == (int)ItemStatus.InProduction)).FirstOrDefault();
                return new[] { firstItem };

            }
            else
            {
                return null;
            }

        }


        public IEnumerable<object> GetCurrentItemInProduction()
        {

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            if (firstOrder != null)
            {

                ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

                var currentItems = items.Where(i => i.ITEMTRACKER.OrderByDescending(it => it.ItemID).All(it => it.ItemStatus != (int)ItemStatus.Complete)
                                                           && i.ITEMTRACKER.Any(it2 => it2.ItemStatus == (int)ItemStatus.InProduction));
                return currentItems.ToList() ;

            }
            else
            {
                return null;
            }

        }
        public IEnumerable<ITEM> GetFirstItemNotInProductionAndNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable()
        {

            ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

            var firstItem = items.Where(i => i.ITEMTRACKER.All(it => it.ItemStatus != (int)ItemStatus.Complete)
                                                           && i.ITEMTRACKER.Any(it2 => it2.ItemStatus != (int)ItemStatus.InProduction)).FirstOrDefault();

            if (firstItem != null)
            {
                return new[] { firstItem };
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<object> GetFirstItemFailedOrNotInProductionFromCurrentOrderAsEnumerable()
        {

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID);

            var firstItem = CheckStatusOfItems(items);

            if (firstItem != null)
            {
                return new[] { firstItem };
            }
            else
            {
                return null;
            }
        }

        private ITEM CheckStatusOfItems(IQueryable<ITEM> items)
        {
            var nextItem =

                from item in items

                from lastStatusOfItem in ERPContext.ITEMTRACKER

                    .Where(it => it.ItemID == item.ItemID)
                    .OrderByDescending(it => it.ItemTrackerID)
                    .Take(1)

                where (lastStatusOfItem.ItemStatus == (int)ItemStatus.Failed || lastStatusOfItem.ItemStatus == (int)ItemStatus.Confirmed)

                select item;

            return nextItem.FirstOrDefault();
        }

        public string GetAvgTimeToProduceAnItem()
        {
            //TODO 

            //return "10";

            var allItems = ERPContext.ITEM as IQueryable<ITEM>;

            var completedItems = allItems.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Complete));

            var completedItemsEnteredProduction =    
                                                  from completed in completedItems
                                                  from itemEnteredProduction in ERPContext.ITEMTRACKER
                                                  .Where(it => it.ItemID == completed.ItemID)
                                                  .OrderBy(it => it.ItemID)
                                                  where (itemEnteredProduction.ItemStatus == (int)ItemStatus.InProduction)
                                            
                                                  select itemEnteredProduction;

            var result = completedItemsEnteredProduction.ToList();

            return result.ToString();
        }


        public IEnumerable<object> GetAvgTimeToProduceAnItemAsList()
        {
            //TODO 

            //return "10";

            var allItems = ERPContext.ITEM as IQueryable<ITEM>;

            var completedItems = allItems.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Complete));

            var completedItemsEnteredProduction =
                                                  from completed in completedItems
                                                  from itemEnteredProduction in ERPContext.ITEMTRACKER
                                                  .Where(it => it.ItemID == completed.ItemID)
                                                  .OrderBy(it => it.ItemID)
                                                  where (itemEnteredProduction.ItemStatus == (int)ItemStatus.InProduction)

                                                  select itemEnteredProduction;

            var result = completedItemsEnteredProduction;

            var resultList = result.ToList();

            return resultList;
        }


        public IEnumerable<ITEM> GetAllItemsFromFirstOrderFailedOrNotInProductionAndNotCompleted()
        {

            ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

            IEnumerable<ITEM> ItemsList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Failed)
                                                           || i.ITEMTRACKER.All(it2 => it2.ItemStatus != (int)ItemStatus.InProduction)
                                                           && i.ITEMTRACKER.Any(it3 => it3.ItemStatus != (int)ItemStatus.Complete)).ToList();


            return ItemsList;

        }

        public IEnumerable<ITEM> GetAllItemsInProductionForCustomerByOrderId(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId) as IQueryable<ITEM>;

            IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.InProduction));

            return itemList;

        }

        public IEnumerable<ITEM> GetAllItemsCompletedForCustomerByOrderId(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId) as IQueryable<ITEM>;

            IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Complete));

            return itemList;

        }

        public IEnumerable<ITEM> GetAllItemsFailedForCustomerByOrderId(int orderId)
        {

            var items = ERPContext.ITEM.Where(i => i.OrderID == orderId) as IQueryable<ITEM>;

            IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Failed));

            return itemList;

        }

        public IEnumerable<ITEM> GetAllItemsInProduction()
        {

            var items = ERPContext.ITEM as IQueryable<ITEM>;

            IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.InProduction));

            return itemList;

        }

        public IEnumerable<ITEM> GetAllItemsCompleted()
        {

            var items = ERPContext.ITEM as IQueryable<ITEM>;

            IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Complete));

            return itemList;

        }

        public IEnumerable<ITEM> GetAllItemsFailed()
        {

            var items = ERPContext.ITEM as IQueryable<ITEM>;

            IEnumerable<ITEM> itemList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Failed));

            return itemList;

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

        public string GetNumberOfCompleteOrders()
        {

            var orders = ERPContext.ORDERS as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.Any(ot => ot.OrderStatus == (int)OrderStatus.Complete));

            var numberOfOrders = ordersList.Count();

            return Convert.ToString(numberOfOrders);

        }


        public string GetNumberOfFailedItems()
        {

            var items = ERPContext.ITEM as IQueryable<ITEM>;

            var itemsList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Failed));

            var numberOfFailed = itemsList.Count();

            return Convert.ToString(numberOfFailed);

        }

        public string GetNumberOfCompleteItems()
        {

            var items = ERPContext.ITEM as IQueryable<ITEM>;

            var itemsList = items.Where(i => i.ITEMTRACKER.Any(it => it.ItemStatus == (int)ItemStatus.Complete));

            var numberOfFailed = itemsList.Count();

            return Convert.ToString(numberOfFailed);

        }
    }
}
