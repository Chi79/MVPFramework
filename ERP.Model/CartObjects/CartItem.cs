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

        private double _price;

        private string _size;

        private string _colour;


        public CartItem( ItemSize size, ItemColour colour, int amountInMls)
        {

            _amountInMls = amountInMls;

            CalculatePrice();

            ConvertSizeEnumToStringProperty(size);

            ConvertColourEnumToStringProperty(colour);

        }

        public int ID { get { return _ID; } set { _ID = value; } }

        public string Size { get { return _size; } }

        public string Colour { get { return _colour; } }

        public int MLs { get { return _amountInMls; } }

        public double Price { get { return _price; }  }


        private void CalculatePrice()
        {
            _price = _amountInMls * 10.5;
        }

        private void ConvertSizeEnumToStringProperty(ItemSize size)
        {

            _size = Enum.GetName(typeof(ItemSize), size).ToString();

        }

        private void ConvertColourEnumToStringProperty(ItemColour colour)
        {

            _colour = Enum.GetName(typeof(ItemColour), colour).ToString();

        }
    }
}




