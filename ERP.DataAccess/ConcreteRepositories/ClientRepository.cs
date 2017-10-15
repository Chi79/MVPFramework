using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.RepositoryInterfaces;
using ERP.DataTables.Tables;
using ERP.Common.Enums;
using ERP.Common.Structs;

namespace ERP.DataAccess.ConcreteRepositories
{
    public class ClientRepository : Repository<CLIENT> , IClientRepository
    {

        private LoginResponse _loginResponse;

        public ClientRepository(ERPContext context) : base(context)  // calls our base constructor Repository<CLIENT>
        {

        }

        public ERPContext ERPContext
        {

            get { return Context as ERPContext; }    // casting our context class as an entity DbContext 

        }

        public LoginResponse LoginRequest(string email, string password)
        {

            var response = ERPContext.CLIENT
                .Where(c => c.Email == email)
                .Where(c => c.Password == password);


            if (!response.Any())
            {

                ReturnNullClient();

            }
            else
            {

                var client = response.FirstOrDefault();

                _loginResponse.ClientType = client.ClientType;

                _loginResponse.ClientEmail = client.Email;

                _loginResponse.ClientName = client.FirstName + " " + client.LastName;

                _loginResponse.CredentialsApproved = true;

            }
            return _loginResponse;

        }

        public void ReturnNullClient()
        {

            _loginResponse.ClientType = 0;

            _loginResponse.ClientEmail = string.Empty;

            _loginResponse.ClientName = string.Empty;

            _loginResponse.CredentialsApproved = false;

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

        public CLIENT GetAClientByEmail(string email)
        {

            return ERPContext.CLIENT.FirstOrDefault(c => c.Email == email) as CLIENT;

        }

        public int GetClientIDByEmail(string email)
        {

            CLIENT client = GetAClientByEmail(email);

            int ID = client.ClientID;

            return ID;

        } 

    }
}
