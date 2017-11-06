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
    public class FetchNumberOfCompleteOrders : IFetchProductionData
    {

        private IUnitOfWork _uOW;

        public FetchNumberOfCompleteOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }


        public string FetchProductionData()
        {

            var result = _uOW.ORDERs.GetNumberOfCompleteOrders();

            return result;

        }

    }
}
