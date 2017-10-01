using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace ERP.Bootstrap
{
    public class Bootstrapper 
    {
        public IContainer Container;

        public void BootstrapStructureMap()
        {
            Container = new Container(AddRegistryInfo);  //creates a new container with the registry info args
        }

        private static void AddRegistryInfo(IRegistry registry)
        {
            registry.Scan(scanner =>
            {
                scanner.AssemblyContainingType<Bootstrapper>();   //scans the assembly which contains the class Bootstrapper
                scanner.LookForRegistries();                      //which is this assembly looking for classes which extend the 
                                                                  //registry class of structure map - we define these classes
                                                                  //in the 'projectname'registry class
            });
        }
    }
}
