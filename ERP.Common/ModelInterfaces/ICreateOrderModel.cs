using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface ICreateOrderModel
    {

        string GetCurrentClientName();

        void ResetSession();

        bool? CheckLoggedInStatus();

        string AddItemToCart(string amountInMls, object itemTypeEnum);

        IEnumerable<object> GetItemsInCart();

        void CreateCartItem(string itemType, int amountInMls);

        void AddItemToSessionCart();

    }
}
