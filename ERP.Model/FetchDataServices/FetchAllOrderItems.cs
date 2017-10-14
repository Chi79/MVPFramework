using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;

namespace ERP.Model.FetchDataServices
{
    public class FetchAllOrderItems : IFetchOrderItemData
    {

        private IUnitOfWork _uOW;

        public FetchAllOrderItems(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing all items in the selected order."; } }

        public IEnumerable<object> FetchItemDataForOrder(int orderId)
        {

            var result = _uOW.ITEMs.GetAllItemsForCustomerByOrderId(orderId).ToList();

            return result;

        }

        

    }
}
