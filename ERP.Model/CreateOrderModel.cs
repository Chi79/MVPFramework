﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.Enums;
using ERP.Model.CartObjects;
using ERP.Common.CartInterfaces;

namespace ERP.Model
{
    public class CreateOrderModel : ICreateOrderModel
    {

        private readonly ISessionService _session;

        private ICartItem _cartItem;

        private IList<object> _cartList;


        public CreateOrderModel(ISessionService session)
        {

            _session = session;
        
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

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

        public void SetNewOrderToProcess()
        {

            _session.OrderHasNotBeenSubmitted = true;

            _session.PreventNavigationToOrderConfirmationPage = false;

        }


        public string AddItemToCart(ItemSize size, ItemColour colour, string amountInMls)
        {
            int amount = Convert.ToInt32(amountInMls);

            var item = CreateCartItem(size, colour, amount);

            bool CartItemIsValid = item.IsValid(item);
            if(CartItemIsValid)
            {

                return AddItemToSessionCart();

            }
            else
            {

                return item.GetBrokenBusinessRules().First();

            }

        }

        public IEnumerable<object> GetItemsInCart()
        {

            var itemsInCart = _session.ItemsInCart;

            return itemsInCart.ToList();

        }

        private CartItem CreateCartItem(ItemSize size, ItemColour colour, int amountInMls)
        {

            _cartItem = new CartItem(size, colour, amountInMls);

            AllocateCartId();

            return _cartItem as CartItem;

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


        private string AddItemToSessionCart()
        {

            int NumberOfItemsInCart = _cartList.Count;

            bool CartIsFull = NumberOfItemsInCart == 6;
            if(CartIsFull)
            {

                return "Cart is Full - Maximum of 6 items per order!";

            }
            else
            {
                _cartList.Add(_cartItem);

                _session.ItemsInCart = _cartList;

                return "One " + _cartItem.Size + " " + _cartItem.Colour
                                                     + " bottle with " 
                                                     + _cartItem.MLs.ToString() 
                                                     + " millileters has been added to your order.";
            }

        }

        public string RemoveItemFromCart(int ID)
        {

            var cartList = _cartList.Cast<CartItem>().ToList();

            var itemToRemove = cartList.FirstOrDefault(c => c.ID == ID);

            cartList.Remove(itemToRemove);

            _session.ItemsInCart = cartList;

            return "Item Removed From Cart";
        }

    }
}
