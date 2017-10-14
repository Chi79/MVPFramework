using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.CartInterfaces;
using ERP.Common.Enums;


namespace ERP.Model.CartObjects
{
    public class CartItem : ICartItem
    {

        private int _ID;

        private int _amountInMls;

        private string _itemType;

        private double _price;


        public CartItem(ItemType itemType, int amountInMls)
        {

            _amountInMls = amountInMls;

            CalculatePrice();

            ConvertItemTypeEnumToString(itemType);

        }

        public int ID { get { return _ID; } set { _ID = value; } }

        public string ItemType { get { return _itemType; } } 

        public int MLs { get { return _amountInMls; } }

        public double Price { get { return _price; }  }


        private void CalculatePrice()
        {
            _price = _amountInMls * 10.5;
        }

        private void ConvertItemTypeEnumToString(ItemType itemType)
        {

            _itemType = Enum.GetName(typeof(ItemType), itemType).ToString().Replace("_", " ");

        }
    }
}




