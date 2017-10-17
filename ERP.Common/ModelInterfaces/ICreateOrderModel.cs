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

        bool CheckLoggedInStatus();

        string AddItemToCart( ItemSize size, ItemColour colour, string amountInMls);

        string RemoveItemFromCart(int ID);

        void SetNewOrderToProcess();

        IEnumerable<object> GetItemsInCart();

    }
}
