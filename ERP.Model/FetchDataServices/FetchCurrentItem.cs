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
    class FetchCurrentItem : IFetchAdminOrderData
    {

        private IUnitOfWork _uOW;

        public FetchCurrentItem(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage
        {
            get
            {
                if(_uOW.ORDERs.GetCurrentItemInProduction() != null)
                {

                    return "Viewing The Current Items Being Produced.</br> Please click a row to view the other items in the order.";

                }
                else
                {

                    return "No Items Are Currently Being Produced...</br> <br>";

                }
            }
        }

        public IEnumerable<object> FetchDataForAdmin()
        {

            var result = _uOW.ORDERs.GetCurrentItemInProduction();

            return result;
       
        }

    }
}
