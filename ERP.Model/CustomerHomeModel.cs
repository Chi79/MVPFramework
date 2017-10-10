using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;

namespace ERP.Model
{
    public class CustomerHomeModel : ICustomerHomeModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;


        public CustomerHomeModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;
        }

        public string GetCurrentClientName()
        {

            return _session.CurrentClientName;

        }

        public bool? CheckLoggedInStatus()
        {

            return _session.LoggedInStatus;

        }

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

    }
}
