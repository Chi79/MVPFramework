using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.RepositoryInterfaces;

namespace ERP.Model
{
    public class OperatorHomeModel : IOperatorHomeModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;


        public OperatorHomeModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;
        }

        public string GetCurrentClientName()
        {

            return _session.CurrentClientName;

        }

        public bool CheckLoggedInStatus()
        {

            return (bool)_session.LoggedInStatus;

        }

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

    }
}
