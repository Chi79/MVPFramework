using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Model.CartObjects;
using ERP.DataTables.Tables;
using ERP.Model.DataMappers;


namespace ERP.Model
{
    public class ConfirmOrderModel : IConfirmOrderModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;

        private IList<object> _cartList;


        public ConfirmOrderModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;

            _cartList = GetItemsInCart().ToList();

        }

        public string GetCurrentClientName()
        {

            return _session.CurrentClientName;

        }

        public bool? CheckLoggedInStatus()
        {

            return _session.LoggedInStatus;

        }

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

        public void ClearOrder()
        {

            _session.ItemsInCart = null;

        }

        public IEnumerable<object> GetItemsInCart()
        {

            var itemsInCart = _session.ItemsInCart;

            return itemsInCart.ToList();

        }

        public string SaveConfirmedOrderToDB()
        {
            bool OrderIsEmpty = CheckForEmptyOrder();
            if(OrderIsEmpty)
            {

                return "Order failed! The order is empty.";

            }
            else
            {

                int orderID = GetOrderID();

                List<CartItem> cartItems = ConvertCartToCartItemsList();

                List<ITEM> orderItems = ConvertCartItemsToItems(cartItems, orderID);

                decimal orderPrice = CalculateOrderPrice(orderItems);

                CreateNewOrder(orderPrice, orderID);

                UpdateDBWithItemsAddedToOrder(orderItems);

                ClearOrder();

                return "Thank you " + GetCurrentClientName() + " Your Order Has Been Placed!";
            }         

        }

        private bool CheckForEmptyOrder()
        {

            return _session.ItemsInCart.Count() == 0;

        }

        private int GetOrderID()
        {

            List<ORDERS> myOrders = _uOW.ORDERs.GetAllOrders().Cast<ORDERS>().ToList();

            if (myOrders.Count == 0)
            {
                return 1;
            }
            else
            {
                ORDERS lastOrder = myOrders.Last();

                return lastOrder.OrderID + 1;
            }

        }

        private List<CartItem> ConvertCartToCartItemsList()
        {

            return GetItemsInCart().Cast<CartItem>().ToList();

        }

        private List<ITEM> ConvertCartItemsToItems(List<CartItem> cartItems, int orderID)
        {

            List<ITEM> myItems = new List<ITEM>();

            foreach (CartItem item in cartItems)
            {
                ITEM newItem = CartItemToItemMapper.ConvertCartItemToItemMapper(item, orderID);

                myItems.Add(newItem);
            }
            return myItems;

        }

        private decimal CalculateOrderPrice(List<ITEM> orderItems)
        {
            decimal price = 0;

            foreach (ITEM item in orderItems)
            {
                price += (decimal)item.ItemPrice;
            }
            return price;
        }

        private void CreateNewOrder(decimal orderPrice, int orderID)
        {

            ORDERS myOrder = new ORDERS() { ClientID = (int)_session.CurrentClientID, OrderPrice = orderPrice };

            _uOW.ORDERs.Add(myOrder);

            _uOW.Complete();

            UpdateOrderTracker(orderID);

        }

        private void UpdateOrderTracker(int orderID)
        {

            ORDERTRACKER trackingInfo = new ORDERTRACKER()
            { OrderID = orderID, OrderStatusID = 0, TimeStamp = DateTime.Now };

            _uOW.ORDERs.UpdateOrderTracker(trackingInfo);

            _uOW.Complete();

        }

        private void UpdateDBWithItemsAddedToOrder(List<ITEM> orderItems)
        {

            _uOW.ITEMs.InsertAllItemsToDB(orderItems);

            _uOW.Complete();

            UpdateItemTracker(orderItems);

        }


        private void UpdateItemTracker(List<ITEM> orderItems)
        {
            foreach(ITEM item in orderItems)
            {
                ITEMTRACKER trackingInfo = new ITEMTRACKER()
                { ItemID = item.ItemID, OrderID = item.OrderID, ItemStatusID = 0, TimeStamp = DateTime.Now };

                _uOW.ORDERs.UpdateItemTracker(trackingInfo);

                _uOW.Complete();
            }

        }
    }
}
