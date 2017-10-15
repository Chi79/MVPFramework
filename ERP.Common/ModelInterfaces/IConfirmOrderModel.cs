using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ModelInterfaces
{
    public interface IConfirmOrderModel
    {

        string GetCurrentClientName();

        void ResetSession();

        bool? CheckLoggedInStatus();

        IEnumerable<object> GetItemsInCart();

        void SaveConfirmedOrderToDB();

        void ClearOrder();
    }
}
