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

        public bool CheckLoggedInStatus()
        {

            return (bool)_session.LoggedInStatus;

        }

        public bool CheckIsNavigationValid()
        {

            return (bool)_session.PreventNavigationToOrderConfirmationPage;

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

            bool IsFirstSubmission = (bool)_session.OrderHasNotBeenSubmitted || CheckForEmptyOrder();
            if(IsFirstSubmission)
            {

                FlagOrderAsProcessed();

                int orderID = GetOrderID();

                List <ITEM> orderItems = ConvertCartToItems(orderID);

                decimal orderPrice = SumItemPrice(orderItems);

                AddOrderToDB(orderPrice, orderID);

                AddItemsToDB(orderItems);

                ClearOrder();

                return "Thank you " + GetCurrentClientName() + " Your Order Has Been Placed!";

            }
            else
            {
                return "Failed To Submit! Order is Empty.";
            }    

        }

        private void FlagOrderAsProcessed()
        {

            _session.OrderHasNotBeenSubmitted = false;

        }

        public bool CheckForEmptyOrder()
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

        private List<ITEM> ConvertCartToItems(int orderID)
        {

            List<CartItem> cartItems = GetItemsInCart().Cast<CartItem>().ToList();

            return ConvertCartItemsToItems(cartItems, orderID);

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

        private decimal SumItemPrice(List<ITEM> orderItems)
        {
            decimal price = 0;

            foreach (ITEM item in orderItems)
            {
                price += (decimal)item.ItemPrice;
            }
            return price;
        }

        private void AddOrderToDB(decimal orderPrice, int orderID)
        {

            ORDERS myOrder = new ORDERS() { ClientID = (int)_session.CurrentClientID, OrderPrice = orderPrice };

            _uOW.ORDERs.Add(myOrder);

            _uOW.Complete();

            UpdateOrderTracker(orderID);

        }

        private void UpdateOrderTracker(int orderID)
        {

            ORDERTRACKER trackingInfo = new ORDERTRACKER()
            { OrderID = orderID, OrderStatus = 0 };

            _uOW.ORDERs.UpdateOrderTracker(trackingInfo);

            _uOW.Complete();

        }

        private void AddItemsToDB(List<ITEM> orderItems)
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
                { ItemID = item.ItemID, OrderID = item.OrderID, ItemStatus = 0, MeasuredWeight= null};

                _uOW.ORDERs.UpdateItemTracker(trackingInfo);

                _uOW.Complete();
            }

        }
    }
}
