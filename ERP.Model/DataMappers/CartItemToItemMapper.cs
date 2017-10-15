using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.CartInterfaces;
using ERP.DataTables.Tables;

namespace ERP.Model.DataMappers
{
    public  class CartItemToItemMapper
    {
        public static ITEM ConvertCartItemToItemMapper(ICartItem cartItem, int orderID)
        {
            ITEM Item = new ITEM()
            {
                Size = cartItem.Size,
                ItemColour = cartItem.Colour,
                ItemPrice = Convert.ToDecimal(cartItem.Price),
                ItemWeight = cartItem.MLs,
                OrderID = orderID           
            };
 
            return Item;

        }
    }
}
