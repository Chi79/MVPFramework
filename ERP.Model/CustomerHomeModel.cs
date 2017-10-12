using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.Enums;
using ERP.DataTables.Tables;

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

        public void SetSelectedOrderIdToSession(int orderId)
        {

            _session.SelectedOrderId = orderId;

        }

        public int GetSelectedOrderIdFromSession()
        {

            int? orderId = _session.SelectedOrderId;

            if(orderId != null)
            {
                return (int)orderId;
            }
            else
            {
                return -1;
            }

        }


        public IEnumerable<object> GetAllOrders()
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmail(_session.CurrentClientEmail)
                                                                   .ToList();

            return result;

        }

        public IEnumerable<object> GetAllConfirmedOrders()
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmailAndStatus(_session.CurrentClientEmail, (int)OrderStatus.Confirmed)
                                                                      .ToList();

            return result;

        }

        public IEnumerable<object> GetAllOrdersInProduction()
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmailAndStatus(_session.CurrentClientEmail, (int)OrderStatus.InProduction)
                                                                      .ToList();

            return result;

        }

        public IEnumerable<object> GetAllCompletedOrders()
        {
            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmailAndStatus(_session.CurrentClientEmail, (int)OrderStatus.Complete)
                                                                      .ToList();

            return result;

        }

        public IEnumerable<object> GetAllItemsForOrder(int orderId)
        {

            var result = _uOW.ITEMs.GetAllItemsForCustomerByOrderId(orderId).ToList();

            return result;

        }
    }
}
