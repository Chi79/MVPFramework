using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.RepositoryInterfaces;
using ERP.DataTables.Tables;
using ERP.Common.Structs;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace ERP.DataAccess.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ERPContext _context;

        public UnitOfWork(ERPContext context)
        {

            _context = context;

            CLIENTs = new ClientRepository(_context); // intitializes the repo with our context object

        }

        public IClientRepository CLIENTs { get; private set; }  //add all the repo interfaces we want to expose


        public void Dispose()
        {

            _context.Dispose();

        }

        public SaveResult Complete()
        {

            SaveResult SaveResult = new SaveResult { };
            SaveResult.Result = 0;
            SaveResult.ErrorMessage = string.Empty;

            try
            {
                SaveResult.Result = _context.SaveChanges();   //attempt to save changes to DB
                SaveResult.Result = 1;                        //if success set to 1
                return SaveResult;
            }
            catch (DbEntityValidationException e)             //if fails record the error message
            {
                foreach (var error in e.EntityValidationErrors)
                {

                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var validation_error in error.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            validation_error.PropertyName, validation_error.ErrorMessage);
                    }
                }
                SaveResult.ErrorMessage = e.Message;
                return SaveResult;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.InnerException);

                System.Data.Entity.Core.UpdateException update_error = (System.Data.Entity.Core.UpdateException)e.InnerException;
                System.Data.SqlClient.SqlException error = (System.Data.SqlClient.SqlException)update_error.InnerException;

                SaveResult.ErrorMessage = error.Message;
                return SaveResult;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                SaveResult.ErrorMessage = e.Message;
                return SaveResult;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                SaveResult.ErrorMessage = e.Message;
                return SaveResult;
            }
        }
    }
}
