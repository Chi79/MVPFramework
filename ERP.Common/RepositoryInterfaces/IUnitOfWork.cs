using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.Structs;

namespace ERP.Common.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IClientRepository CLIENTs { get; }   //add all repository interfaces here that we wish to expose to the model

        IOrdersRepository ORDERs { get; }

        IOrdersRepository ITEMs { get; }

        SaveResult Complete();  //for saving changes to the DB - provides feedback on any errors

    }
}
