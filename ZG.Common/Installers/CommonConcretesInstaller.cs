using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZG.Common.Abstract;
using ZG.Common.Concrete;

namespace ZG.Common.Installers
{
    public class CommonConcretesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //TODO: make sure EmailProcessor is registered proberly.
            container.Register(Component.For(typeof(IEmailProcessor)).ImplementedBy<EmailProcessor>().LifestyleTransient(),
                               Component.For(typeof(IEmailSettingsFactory)).ImplementedBy<EmailSettingsFactory>().LifestyleTransient());
        }
    }
}
