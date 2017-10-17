using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ServiceInterfaces
{
    public interface ISessionService
    {

        string CurrentClientEmail { get; set; }

        string CurrentClientName { get; set; }

        int? CurrentClientID { get; set; }

        bool? LoggedInStatus { get; set; }

        int? SelectedOrderId { get; set; }

        bool? OrderHasNotBeenSubmitted { get; set; }

        bool? PreventNavigationToOrderConfirmationPage { get; set; }

        IEnumerable<object> ItemsInCart { get; set; }

    }
}
