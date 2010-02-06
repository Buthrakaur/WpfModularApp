using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;

namespace WpfModularApp.Person
{
    public class Installer: Castle.Windsor.IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.IConfigurationStore store)
        {
            container.Register(Component.For<Service.IPersonRepository>()
                .ImplementedBy<Service.PersonRepository>());
            container.Register(Component.For<Service.IPersonQuery>()
                .ImplementedBy<Service.PersonQuery>());
        }
    }
}
