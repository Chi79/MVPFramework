﻿using System;
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

        private readonly ICartItem _cartItem;


        public CreateOrderModel(ISessionService session, IUnitOfWork uOW, ICartItem cartItem)
        {

            _session = session;

            _uOW = uOW;

            _cartItem = cartItem;

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


        public event EventHandler<string> BottleIsEmpty;

        public void AddItemToCart(string amountInMls , object itemTypeEnum)
        {
            int amount = Convert.ToInt32(amountInMls);

            int empty = 0;

            if (amount == empty)
            {

                BottleIsEmpty?.Invoke(this, "An item must contain some water! Please select the amount in mls before adding the item.");
  
            }
            else
            {

                string itemType = ConvertItemTypeEnumToString(itemTypeEnum);

                CreateCartItem(itemType, amount);

                AddItemToSessionCart();

            }
            
        }

        public string ConvertItemTypeEnumToString(object itemTypeEnum)
        {

            return Enum.GetName(typeof(ItemType), itemTypeEnum).ToString().Replace("_", " ");

        }

        public IEnumerable<object> GetItemsInCart()
        {

            var itemsInCart = _session.ItemsInCart;

            return itemsInCart.ToList();

        }

        public void CreateCartItem(string itemType, int amountInMls)
        {

            _cartItem.ItemType = itemType;

            _cartItem.MLs = amountInMls;

            _cartItem.Price = _cartItem.CalculatePrice();

            AllocateCartId();

        }

        public void AllocateCartId()
        {

            var CartList = GetItemsInCart().ToList();

            if (CartList.Count == 0)
            {
                _cartItem.ID = 1;
            }
            else
            {
                CartItem lastInList = CartList.Last() as CartItem;

                _cartItem.ID = lastInList.ID + 1;
            }

        }


        public event EventHandler<string> CartIsFull;

        public event EventHandler<string> ItemAddedToCart;


        public void AddItemToSessionCart()
        {

            var CartList = GetItemsInCart().ToList();

            int NumberOfItemsInCart = CartList.Count();

            int MaximumNumberOfItemsPerOrder = 6;

            if(NumberOfItemsInCart == MaximumNumberOfItemsPerOrder)
            {

                CartIsFull?.Invoke(this, "Cart is Full - Maximum of 6 items per order!");

            }
            else
            {
                CartList.Add(_cartItem);

                _session.ItemsInCart = CartList;

                ItemAddedToCart?.Invoke(this, "One " + _cartItem.ItemType 
                                                     + " bottle with " 
                                                     + _cartItem.MLs.ToString() 
                                                     + " millileters has been added to your order.");
            }

        }

    }
}