using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using ERP.Presenters.Bases;
using ERP.Model;

namespace ERP.Bootstrap.Registries
{
    public class ERPRegistry : Registry
    {
        public ERPRegistry()
        {
            Scan(scanner =>
            {
                scanner.RegisterConcreteTypesAgainstTheFirstInterface();     
                scanner.AssemblyContainingType<PresenterBase>();             
                scanner.AssemblyContainingType<WelcomeModel>();              
                scanner.WithDefaultConventions();                            
                scanner.SingleImplementationsOfInterface();                  
            });

            //here we define the classes to be resolved and configuure the container to search through the
            //assembly which contains our PresenterBase class - which is the common project dir. All Classes that have 
            // a corresponding Interface where the naming conventions are Classname - IClassname will be added to the reg.
            // we will need to add the assembly for any other classes that will need to have an interface dependency resolved
            // like the models ect...
        }
    }
}
