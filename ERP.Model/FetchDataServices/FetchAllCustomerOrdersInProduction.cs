using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.Enums;

namespace ERP.Model.FetchDataServices
{
    public class FetchAllCustomerOrdersInProduction : IFetchCustomerOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllCustomerOrdersInProduction(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing orders currently in production.Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForCustomer(string customerEmail)
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerInProductionWithHiddenFields(customerEmail).ToList();

            return result;

        }

    }
}
