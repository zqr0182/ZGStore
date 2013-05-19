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
    public class ConcretesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IEmailProcessor)).ImplementedBy<EmailProcessor>().LifestylePerWebRequest());
        }
    }
}
