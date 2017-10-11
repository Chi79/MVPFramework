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

        private List<object> _emptyList = new List<object>();

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

        public IEnumerable<T> NoDataFound<T>()
        {

            return _emptyList as IEnumerable<T>;

        }

        public IEnumerable<object> GetAllOrders()
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmail(_session.CurrentClientEmail)
                                                                   .ToList();

            if (result.Count == 0)
            {
                return NoDataFound<ORDERS>();
            }
            else
            {
                return result;
            }

        }

        public IEnumerable<object> GetAllConfirmedOrders()
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmailAndStatus(_session.CurrentClientEmail, (int)OrderStatus.Confirmed)
                                                                      .ToList();
            if (result.Count == 0)
            {
                return NoDataFound<ORDERS>();
            }
            else
            {
                return result;
            }

        }

        public IEnumerable<object> GetAllOrdersInProduction()
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmailAndStatus(_session.CurrentClientEmail, (int)OrderStatus.InProduction)
                                                                      .ToList();
            if (result.Count == 0)
            {
                return NoDataFound<ORDERS>();
            }
            else
            {
                return result;
            }

        }

        public IEnumerable<object> GetAllCompletedOrders()
        {
            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmailAndStatus(_session.CurrentClientEmail, (int)OrderStatus.Complete)
                                                                      .ToList();
        
            if (result.Count == 0)
            {
                return NoDataFound<ORDERS>();
            }
            else
            {
                return result;
            }

        }

        public IEnumerable<object> GetAllItemsForOrder(int orderId)
        {

            var result = _uOW.ITEMs.GetAllItemsForCustomerByOrderId(orderId).ToList();

            if (result.Count == 0)
            {
                return NoDataFound<ITEM>();
            }
            else
            {
                return result;
            }

        }
    }
}
