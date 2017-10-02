using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.RepositoryInterfaces;
using System.Data.Entity;
using System.Linq.Expressions;


namespace ERP.DataAccess.ConcreteRepositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {

            Context = context;

        }

        public T Get()
        {

            return Context.Set<T>().Find();

        }
        public void Add(T type)
        {

            Context.Set<T>().Add(type);

        }
        public void Remove(T type)
        {

            Context.Set<T>().Remove(type);

        }
        public IEnumerable<T> GetAll()
        {

            return Context.Set<T>().ToList();

        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {

            return Context.Set<T>().Where(predicate);

        }
    }
}
