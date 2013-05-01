using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ZG.Repository.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<UserRepository>()
                                  .Where(type => type.Name.EndsWith("Repository") && !type.IsInterface)
                                  .WithServiceDefaultInterfaces()
                                  .LifestylePerWebRequest(),
                                  
                                  Component.For<IUnitOfWork>().ImplementedBy<ZGStoreUnitOfWork>().LifestylePerWebRequest(),

                                  Component.For<ZGStoreContext>().ImplementedBy<ZGStoreContext>().LifestylePerWebRequest()
                                  );
        }
    }
}
