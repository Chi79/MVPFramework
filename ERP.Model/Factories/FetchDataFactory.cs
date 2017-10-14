using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Model.FetchDataServices;
using ERP.Common.FactoryInterfaces;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.Enums;

namespace ERP.Model.Factories
{
    public class FetchDataFactory : IFetchDataFactory
    {

        private IUnitOfWork _uOW;

        private Dictionary<OrdersToFetch, IFetchCustomerOrderData> CustomerOrderData;

        private Dictionary<ItemsToFetch, IFetchOrderItemData> OrderItemData;

        public FetchDataFactory(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public void LoadCustomerOrderDictionary(IUnitOfWork uOW)
        {

            if(CustomerOrderData == null)
            {

                CustomerOrderData = new Dictionary<OrdersToFetch, IFetchCustomerOrderData>();

                CustomerOrderData.Add(OrdersToFetch.AllOrders, new FetchAllCustomerOrders(uOW));
                CustomerOrderData.Add(OrdersToFetch.AllConfirmed, new FetchAllConfirmedCustomerOrders(uOW));
                CustomerOrderData.Add(OrdersToFetch.AllInProduction, new FetchAllCustomerOrdersInProduction(uOW));
                CustomerOrderData.Add(OrdersToFetch.AllCompleted, new FetchAllCompletedCustomerOrders(uOW));

            }
        }


        public IEnumerable<object> FetchDataForCustomer(OrdersToFetch ordersToFetch, string customerEmail)
        {

            LoadCustomerOrderDictionary(_uOW);

            var data = CustomerOrderData[ordersToFetch].FetchDataForCustomer(customerEmail);

            return data;

        }

        public string FetchOrderDataInfoMessage(OrdersToFetch ordersToFetch)
        {

            LoadCustomerOrderDictionary(_uOW);

            var info = CustomerOrderData[ordersToFetch].InfoMessage;

            return info;

        }


        public void LoadOrderItemDictionary(IUnitOfWork uOW)
        {

            if (OrderItemData == null)
            {

                OrderItemData = new Dictionary<ItemsToFetch, IFetchOrderItemData>();

                OrderItemData.Add(ItemsToFetch.AllItemsInOrder, new FetchAllOrderItems(uOW));

            }
        }


        public IEnumerable<object> FetchOrderItemData(ItemsToFetch itemsToFetch, int orderId)
        {

            LoadOrderItemDictionary(_uOW);

            var data = OrderItemData[itemsToFetch].FetchItemDataForOrder(orderId);

            return data;

        }

        public string FetchItemDataInfoMessage(ItemsToFetch itemsToFetch)
        {

            LoadOrderItemDictionary(_uOW);

            var info = OrderItemData[itemsToFetch].InfoMessage;

            return info;

        }

    }
}
