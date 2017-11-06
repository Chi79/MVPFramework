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
    class FetchAllCompletedOrders : IFetchAdminOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllCompletedOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing all completed orders. Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForAdmin()
        {

            var result = _uOW.ORDERs.GetAllOrdersCompleted().ToList();

            return result;

        }

    }
}
