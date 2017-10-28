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
    public class FetchAllConfirmedCustomerOrders : IFetchCustomerOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllConfirmedCustomerOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing confirmed orders awaiting production. Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForCustomer(string customerEmail)
        {

            var result = _uOW.ORDERs.GetAllConfirmedOrdersForCustomerWithHiddenFields(customerEmail).ToList();

            return result;

        }

      }
    }
