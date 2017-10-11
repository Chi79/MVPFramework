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

        bool? LoggedInStatus { get; set; }

        int? SelectedOrderId { get; set; }

    }
}
