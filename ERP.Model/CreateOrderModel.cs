using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.Enums;
using ERP.Model.CartObjects;
using ERP.Common.CartInterfaces;

namespace ERP.Model
{
    public class CreateOrderModel : ICreateOrderModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;

        private ICartItem _cartItem;

        private IList<object> _cartList;


        public CreateOrderModel(ISessionService session, IUnitOfWork uOW)
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


        public event EventHandler<string> ItemIsEmpty;

        public void AddItemToCart(string amountInMls , ItemType itemType)
        {

            int amount = Convert.ToInt32(amountInMls);

            bool BottleIsEmpty = amount == 0;
            if (BottleIsEmpty)
            {

                ItemIsEmpty?.Invoke(this, "An item must contain some water! Please select the amount in mls before adding the item.");
  
            }
            else
            {

                CreateCartItem(itemType, amount);

                AddItemToSessionCart();

            }
            
        }

        public IEnumerable<object> GetItemsInCart()
        {

            var itemsInCart = _session.ItemsInCart;

            return itemsInCart.ToList();

        }

        public void CreateCartItem(ItemType itemType, int amountInMls)
        {

            _cartItem = new CartItem(itemType, amountInMls);

            AllocateCartId();

        }

        public void AllocateCartId()
        {

            if (_cartList.Count == 0)
            {
                _cartItem.ID = 1;
            }
            else
            {
                CartItem lastInList = _cartList.Last() as CartItem;

                _cartItem.ID = lastInList.ID + 1;
            }

        }


        public event EventHandler<string> CartFull;

        public event EventHandler<string> ItemAddedToCart;


        public void AddItemToSessionCart()
        {

            int NumberOfItemsInCart = _cartList.Count;

            bool CartIsFull = NumberOfItemsInCart == 6;
            if(CartIsFull)
            {

                CartFull?.Invoke(this, "Cart is Full - Maximum of 6 items per order!");

            }
            else
            {
                _cartList.Add(_cartItem);

                _session.ItemsInCart = _cartList;

                ItemAddedToCart?.Invoke(this, "One " + _cartItem.ItemType 
                                                     + " bottle with " 
                                                     + _cartItem.MLs.ToString() 
                                                     + " millileters has been added to your order.");
            }

        }

        public void RemoveItemFromCart(int ID)
        {

            var cartList = _cartList.Cast<CartItem>().ToList();

            var itemToRemove = cartList.FirstOrDefault(c => c.ID == ID);

            cartList.Remove(itemToRemove);


            _session.ItemsInCart = cartList;

        }

    }
}
