using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DataTables.Tables;
using ERP.Common.Structs;

namespace ERP.Common.RepositoryInterfaces
{
    public interface IClientRepository : IRepository<CLIENT>
    {
        LoginResponse LoginRequest(string email, string password);

        IEnumerable<CLIENT> GetAllCustomers();

        IEnumerable<CLIENT> GetAllOperators();

        IEnumerable<CLIENT> GetAllAdministrators();

        IEnumerable<CLIENT> GetClientByName(string name);

        CLIENT GetAClientByName(string clientName);

        CLIENT GetAClientByEmail(string emai);

        List<string> GetAllClientNames();

        int GetClientIDByEmail(string email);
    }
}
