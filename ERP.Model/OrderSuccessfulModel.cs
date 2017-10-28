using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Model.CartObjects;
using ERP.DataTables.Tables;
using ERP.Model.DataMappers;


namespace ERP.Model
{
    public class OrderSuccessfulModel : IOrderSuccessfulModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;


        public OrderSuccessfulModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;

            PreventNavigationToOrderConfirmationPage();

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

        public void PreventNavigationToOrderConfirmationPage()
        {

            _session.PreventNavigationToOrderConfirmationPage = true;

        }


        public IEnumerable<object> GetLastOrder()
        {

            var LastOrder = _uOW.ORDERs.GetAllOrdersForCustomerByEmail(_session.CurrentClientEmail).Last();

            int lastOrderID = LastOrder.OrderID;

            var ItemsInLastOrder = _uOW.ITEMs.GetAllItemsForCustomerByOrderIdWithHiddenFields(lastOrderID);

            return ItemsInLastOrder.ToList();

        }

    }
}
