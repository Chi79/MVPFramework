using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ValidatorInterfaces;

namespace ERP.Model.Validators
{
    public class Validate<T> : IValidate<T> where T : class
    {
        private List<string> _brokenRules = new List<string>();
        public bool IsValid(T entity)
        {
            ClearCollectionOfBrokenRules();
            CheckForBrokenRules(entity);
            return _brokenRules.Count == 0;
        }
        public void AddBrokenRule(string brokenRule)
        {
            _brokenRules.Add(brokenRule);
        }

        public virtual void CheckForBrokenRules(T entity)
        {
            //to override and implement in classes that inherit this class
        }

        public void ClearCollectionOfBrokenRules()
        {
            _brokenRules.Clear();
        }

        public IEnumerable<string> GetBrokenBusinessRules()
        {
            return _brokenRules;
        }
    }
}
