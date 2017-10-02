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
        IEnumerable<CLIENT> GetAllClientsThatAreCustomers();

        IEnumerable<CLIENT> GetAllClientsThatAreOperators();

        IEnumerable<CLIENT> GetAllClientsThatAreAdministrators();

        IEnumerable<CLIENT> GetClientByName(string name);

        CLIENT GetAClientByName(string clientName);

        List<string> GetAllClientNames();
    }
}
