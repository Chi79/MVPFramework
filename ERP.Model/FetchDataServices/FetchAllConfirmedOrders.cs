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
    public class FetchAllConfirmedOrders : IFetchAdminOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllConfirmedOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing confirmed orders awaiting production. Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForAdmin()
        {

            var result = _uOW.ORDERs.GetAllConfirmedOrdersAsObject().ToList();

            return result;

        }

      }
    }
