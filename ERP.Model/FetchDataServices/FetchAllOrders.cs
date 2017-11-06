using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;

namespace ERP.Model.FetchDataServices
{
    public class FetchAllOrders : IFetchAdminOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing all orders. Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForAdmin()
        {

            var result = _uOW.ORDERs.GetAllOrdersAsObject().ToList();

            //return result;

            //var result = _uOW.ORDERs.GetFirstOrderInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetFirstOrderNotInProductionAndNotCompletedAsEnumerable();

            //var result = _uOW.ORDERs.GetAllItemsFromFirstOrderNotInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetAllItemsInProductionButNotCompletedFromFirstOrderInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetFirstItemInProductionButNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

            //var result = _uOW.ORDERs.GetFirstItemNotInProductionAndNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

            //var result = _uOW.ORDERs.GetAllItemsFromFirstOrderNotInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetFirstOrderInProductionAndNotCompletedAsEnumerable();

            //var result = _uOW.ORDERs.GetFirstItemFailedOrNotInProductionFromCurrentOrderAsEnumerable();

            //var result = _uOW.ORDERs.IsOrderCompleteByOrderId(4);

            //var result = _uOW.ORDERs.GetAllItemsFromFirstOrderFailedOrNotInProductionAndNotCompleted();

            return result;

        }
    }
}
