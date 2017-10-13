using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.CartInterfaces;


namespace ERP.Model.CartObjects
{
    public class CartItem : ICartItem
    {

        private int _ID;

        private int _amountInMls;

        private string _itemType;

        private double _price;

        public CartItem()
        {

        }
        public CartItem(int ID, string itemType, int amountInMls)
        {

            _ID = ID;

            _itemType = itemType;

            _amountInMls = amountInMls;

            _price = CalculatePrice();

        }

        public int ID { get { return _ID; } set { _ID = value; } }

        public string ItemType { get { return _itemType; } set { _itemType = value; } } 

        public int AmountInMls { get { return _amountInMls; } set { _amountInMls = value; } }

        public double Price { get { return _price; } set { _price = CalculatePrice(); } }

        public double CalculatePrice()
        {
            return _amountInMls * 10.5;
        }
    }
}




