using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;

namespace ERP.Model.FetchDataServices
{
    public class FetchAllCustomerOrders : IFetchCustomerOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllCustomerOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing all orders. Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForCustomer(string customerEmail)
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmail(customerEmail).ToList();

            return result;

        }
    }
}
