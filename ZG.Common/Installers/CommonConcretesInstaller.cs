﻿using System;
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
            container.Register(Component.For(typeof(IEmailSender)).ImplementedBy<EmailSender>().LifestyleTransient(),
                               Component.For(typeof(IEmailSettingsFactory)).ImplementedBy<EmailSettingsFactory>().LifestyleTransient());
        }
    }
}
