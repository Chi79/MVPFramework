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
    class FetchCurrentOrder : IFetchAdminOrderData
    {

        private IUnitOfWork _uOW;

        public FetchCurrentOrder(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage
        {
            get
            {
                if(_uOW.ORDERs.GetCurrentOrderInProduction() != null)
                {

                    return "Viewing The Current Order Being Produced.</br> Please click a row to view the order items.";

                }
                else
                {

                    return "No Order Is Currently Being Produced...</br> <br>";

                }         
            }
        }

        public IEnumerable<object> FetchDataForAdmin()
        {

            var result = _uOW.ORDERs.GetCurrentOrderInProduction();

            if(result != null)
            {
                return result.ToList();
            }
            else
            {
                return null;
            }

        }

    }
}
