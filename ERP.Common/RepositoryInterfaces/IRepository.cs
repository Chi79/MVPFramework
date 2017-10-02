using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.RepositoryInterfaces
{
    public interface IRepository<T> where T : class 
    {
        T Get();
        void Add(T type);
        void Remove(T type);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate); 
    }
    //generic base repository interface implemented by all repositories with some generic queries - we can extend these
    //in the specific repositories that are dedicated to a specific type
}
