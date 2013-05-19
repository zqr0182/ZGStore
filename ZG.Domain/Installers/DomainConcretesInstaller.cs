using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZG.Domain.Abstract;
using ZG.Domain.Concrete;

namespace ZG.Domain.Installers
{
    public class DomainConcretesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IOrderProcessor)).ImplementedBy<OrderProcessor>().LifestylePerWebRequest());
        }
    }
}
