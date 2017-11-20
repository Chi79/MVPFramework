using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.RepositoryInterfaces;
using ERP.DataTables.Tables;
using ERP.Common.Enums;
using System.Data.Entity;

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

        public IEnumerable<ORDERS> GetAllOrdersInProduction()
        {

            //ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete
                                            && o.ORDERTRACKER.Any(ot2 => ot2.OrderStatus == (int)OrderStatus.InProduction)));

            return ordersList;

        }

        public IEnumerable<object> GetAllOrdersInProductionAsObject()
        {

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

        public IEnumerable<ORDERS> GetAllConfirmedOrders()
        {

            var orders = ERPContext.ORDERS.OrderBy(o => o.OrderID) as IQueryable<ORDERS>;

            var ordersList = orders.Where(o => o.ORDERTRACKER.All(ot => ot.OrderStatus != (int)OrderStatus.Complete && ot.OrderStatus
                                                                                       != (int)OrderStatus.InProduction));

            return ordersList;

        }

        public ORDERS GetFirstOrderToProduce()
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


        public IEnumerable<ORDERS> GetFirstOrderToProduceAsEnumerable()
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

        public IEnumerable<ITEM> GetAllItemsFromNextOrderToProduce()
        {

            var firstOrder = GetFirstOrderToProduce();

            var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID).OrderBy(i => i.ItemID);

            var itemsList = items.Where(i => i.ITEMTRACKER.All(it => it.ItemStatus != (int)ItemStatus.Complete
                                                                  && it.ItemStatus != (int)ItemStatus.InProduction)).ToList();

            return itemsList;

        }

        public IEnumerable<ITEM> GetAllItemsInProductionFromCurrentOrder()
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

        public IEnumerable<ITEM> GetAllItemsInProductionFromCurrentOrderAsEnumerable()
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


        public IEnumerable<object> GetCurrentItemsInProduction()
        {

            var firstOrder = GetFirstOrderInProductionAndNotCompleted();

            if (firstOrder != null)
            {

                ERPContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var items = ERPContext.ITEM.Where(i => i.OrderID == firstOrder.OrderID) as IQueryable<ITEM>;

                var currentItems = items.Where(i => i.ITEMTRACKER.OrderByDescending(it => it.ItemID).All(it => it.ItemStatus != (int)ItemStatus.Complete)
                                                           && i.ITEMTRACKER.OrderByDescending(it2 => it2.ItemTrackerID).Take(1).Any(it2 => it2.ItemStatus == (int)ItemStatus.InProduction));
                return currentItems.ToList() ;

            }
            else
            {
                return null;
            }

        }
        public IEnumerable<ITEM> GetFirstItemToProduceFromCurrentOrderAsEnumerable()
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

        public void ResetAllItemsInProduction()
        {
            var currentOrder = GetFirstOrderInProductionAndNotCompleted();

            var items = ERPContext.Set<ITEM>().Where(i => i.OrderID == currentOrder.OrderID);

            var currentItemsInProduction = items.Where(it => it.ITEMTRACKER.Any(it1 => it1.ItemStatus == (int)ItemStatus.InProduction)

                                                           && it.ITEMTRACKER.Any(it2 => it2.ItemStatus != (int)ItemStatus.Complete));

            var itemTrackers = from currentItems in currentItemsInProduction
                               from trackers in ERPContext.Set<ITEMTRACKER>()
                               .Where(it => it.ItemID == currentItems.ItemID)
                               .OrderByDescending(it => it.ItemTrackerID).Take(1)

                               select trackers;


            foreach (var tracker in itemTrackers)
            {
                ITEMTRACKER newTracker = new ITEMTRACKER()
                {
                    ItemID = tracker.ItemID,
                    OrderID = tracker.OrderID,
                    ItemStatus = (int)ItemStatus.Confirmed,
                    MeasuredWeight = null

                };

                ERPContext.Set<ITEMTRACKER>().Add(newTracker);
                
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


        public string GetAvgTimeToProduceAnOrder()
        {

            var allTrackers = ERPContext.ORDERTRACKER as IQueryable<ORDERTRACKER>;

            var completedTrackers = allTrackers.Where(ot => ot.OrderStatus == (int)OrderStatus.Complete);

            int totalCompletedOrders = completedTrackers.Count();

            if (totalCompletedOrders != 0)
            {

                var productionTimes = from completed in completedTrackers
                                      from tracker in ERPContext.ORDERTRACKER
                                     .Where(ot => ot.OrderID == completed.OrderID && ot.OrderStatus == (int)OrderStatus.InProduction)
                                     .OrderBy(ot => ot.OrderTrackerID)
                                     .Take(1)

                                     select DbFunctions.DiffSeconds(tracker.TimeStamp, completed.TimeStamp);

                int? totalTimeToCompleteAllOrders = (int)productionTimes.Sum();

                var AvgTimeToCompleteAnOrder = totalTimeToCompleteAllOrders / totalCompletedOrders;

                return AvgTimeToCompleteAnOrder.ToString();

            }           
            else
            {

                return null;

            }
            
        }


        public string GetAvgTimeToProduceTheLastOrder()
        {

            var allTrackers = ERPContext.ORDERTRACKER as IQueryable<ORDERTRACKER>;

            var completedTracker = allTrackers.Where(ot => ot.OrderStatus == (int)OrderStatus.Complete)
                                                              .OrderByDescending(ot => ot.OrderTrackerID)
                                                              .FirstOrDefault();

            if (completedTracker != null)
            {

                var productionTime =  ERPContext.ORDERTRACKER
                                     .Where(ot => ot.OrderID == completedTracker.OrderID && ot.OrderStatus == (int)OrderStatus.InProduction)
                                     .OrderBy(ot => ot.OrderTrackerID)
                                     .FirstOrDefault();


                TimeSpan TimeToCompleteOrder = completedTracker.TimeStamp - productionTime.TimeStamp;

                var AvgTimeToCompleteOrder = TimeToCompleteOrder.TotalSeconds;

                return TimeFormatted(AvgTimeToCompleteOrder);

            }
            else
            {

                return null;

            }

        }

        private string TimeFormatted(double orderTime)
        {

            int time = Convert.ToInt32(orderTime);

            var hrs = ~~(time / 3600);
            var mins = ~~((time % 3600) / 60);
            var secs = time % 60;

            var formattedTime = "";

            if (hrs > 0)
            {
                formattedTime += "" + hrs + ":" + (mins < 10 ? "0" : "");
                formattedTime += "" + mins + ":" + (secs < 10 ? "0" : "");
                formattedTime += "" + secs;
            }
            else
            {
                formattedTime += "00:" + (mins < 10 ? "0" : "") + mins + ":" + (secs < 10 ? "0" : "");
                formattedTime += "" + secs;
            }
            
            return formattedTime;

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
