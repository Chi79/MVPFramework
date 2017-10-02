using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DataTables.Tables;

namespace ERP.Common.RepositoryInterfaces
{
    public interface IClientRepository : IRepository<CLIENT>
    {
        IEnumerable<CLIENT> GetAllCustomers();

        IEnumerable<CLIENT> GetAllOperators();

        IEnumerable<CLIENT> GetAllAdministrators();

        IEnumerable<CLIENT> GetClientByName(string name);

        CLIENT GetAClientByName(string clientName);

        List<string> GetAllClientNames();
    }
}
