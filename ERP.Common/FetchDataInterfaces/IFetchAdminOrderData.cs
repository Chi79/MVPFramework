using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.FetchDataInterfaces
{
    public interface IFetchAdminOrderData
    {

        IEnumerable<object> FetchDataForAdmin();

        string InfoMessage { get; }
    }
}
