using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.Enums;
using ERP.Common.FactoryInterfaces;

namespace ERP.Model
{
    public class AdminHomeModel : IAdminHomeModel
    {

        private readonly ISessionService _session;

        private readonly IFetchDataFactory _factory;


        public AdminHomeModel(ISessionService session, IFetchDataFactory factory)
        {

            _session = session;

            _factory = factory;

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

        public void SetSelectedOrderIdToSession(int orderId)
        {

            _session.SelectedOrderId = orderId;

        }

        public int GetSelectedOrderIdFromSession()
        {

            int? orderId = _session.SelectedOrderId;

            return (int)orderId;

        }

        public IEnumerable<object> FetchOrderData(OrdersToFetch ordersToFetch)
        {

            var data = _factory.FetchDataForAdmin(ordersToFetch);

            return data;

        }

        public string FetchOrderDataInfoMessage(OrdersToFetch ordersToFetch)
        {

            var info = _factory.FetchAdminOrderDataInfoMessage(ordersToFetch);

            return info;

        }

        public IEnumerable<object> FetchItemsData(ItemsToFetch itemsToFetch)
        {
            int orderId = GetSelectedOrderIdFromSession();

            var data = _factory.FetchOrderItemData(itemsToFetch, orderId);

            return data;

        }

        public string FetchItemDataInfoMessage(ItemsToFetch itemsToFetch)
        {

            var info = _factory.FetchItemDataInfoMessage(itemsToFetch);

            return info;

        }

        public string GetNumberOfFailedItems()
        {

            var data = _factory.FetchProductionData(DataToFetch.NumberOfItemsFailed);

            return data;

        }

        public string GetNumberOfCompleteItems()
        {

            var data = _factory.FetchProductionData(DataToFetch.NumberOfItemsCompleted);

            return data;

        }

        public string GetNumberOfCompleteOrders()
        {

            var data = _factory.FetchProductionData(DataToFetch.NumberOfOrdersCompleted);

            return data;

        }

        public string GetAvgTimeToProduceAnItem()
        {

            var data = _factory.FetchProductionData(DataToFetch.AvgTimeToProduceAnItem);

            //return data;

            return  "11";

        }
    }
}
