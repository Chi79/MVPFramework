using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.RepositoryInterfaces;
using ERP.DataTables.Tables;
using ERP.Common.Enums;

namespace ERP.DataAccess.ConcreteRepositories
{
    public class ClientRepository : Repository<CLIENT> ,IClientRepository
    {
        public ClientRepository(ERPContext context) : base(context)  // calls our base constructor Repository<CLIENT>
        {

        }

        public ERPContext ERPContext
        {

            get { return Context as ERPContext; }    // casting our context class as an entity DbContext 

        }

        public IEnumerable<CLIENT> GetAllCustomers()
        {

            return ERPContext.CLIENT.Where(c => c.ClientType == (int)ClientType.Customer).OrderBy(c => c.FirstName);

        }

        public IEnumerable<CLIENT> GetAllOperators()
        {

            return ERPContext.CLIENT.Where(c => c.ClientType == (int)ClientType.Operator).OrderBy(c => c.FirstName);

        }

        public IEnumerable<CLIENT> GetAllAdministrators()
        {

            return ERPContext.CLIENT.Where(c => c.ClientType == (int)ClientType.Admin).OrderBy(c => c.FirstName);

        }

        public IEnumerable<CLIENT> GetClientByName(string name)
        {

            return ERPContext.CLIENT.Where(c => c.FirstName == name);

        }

        public CLIENT GetAClientByName(string clientName)
        {

            return ERPContext.CLIENT.FirstOrDefault(c => c.FirstName.Equals(clientName));

        }

        public List<string> GetAllClientNames()
        {

            return ERPContext.CLIENT.Select(client => client.FirstName + " " + client.LastName).ToList();

        }

    }
}
