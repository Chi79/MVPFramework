using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;

namespace ERP.Model.FetchDataServices
{
    public class FetchAllOrderItemsAdmin : IFetchOrderItemData
    {

        private IUnitOfWork _uOW;

        public FetchAllOrderItemsAdmin(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "</br> Viewing all items in the selected order"; } }

        public IEnumerable<object> FetchItemDataForOrder(int orderId)
        {
            
            var result = _uOW.ITEMs.GetAllItemsForCustomerByOrderIdAsObject(orderId).ToList();

            return result;

        }

        

    }
}
