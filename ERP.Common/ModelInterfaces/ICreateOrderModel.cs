using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.Enums;

namespace ERP.Common.ModelInterfaces
{
    public interface ICreateOrderModel
    {

        string GetCurrentClientName();

        void ResetSession();

        bool? CheckLoggedInStatus();

        void AddItemToCart( ItemSize size, ItemColour colour, string amountInMls);

        void RemoveItemFromCart(int ID);

        IEnumerable<object> GetItemsInCart();

        event EventHandler<string> CartFull;

        event EventHandler<string> ItemAddedToCart;

        event EventHandler<string> ItemIsEmpty;

    }
}
