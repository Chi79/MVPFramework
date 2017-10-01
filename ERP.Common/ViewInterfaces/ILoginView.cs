using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface ILoginView
    {
        string Email { get; }

        string Password { get; }

        string Message { set; }

        void RedirectToCustomerHomePage();

        void RedirectToOperatorHomePage();

        void RedirectToAdminHomePage();

        event EventHandler<EventArgs> LoginAttempt;
    }
}
