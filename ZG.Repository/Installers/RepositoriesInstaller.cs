using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ZG.Repository.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(ZGStoreRepository<>)).LifestylePerWebRequest(),
                               Component.For<IUnitOfWork>().ImplementedBy<ZGStoreUnitOfWork>().LifestylePerWebRequest(),
                               Component.For<ZGStoreContext>().ImplementedBy<ZGStoreContext>().LifestylePerWebRequest());
        }
    }
}
