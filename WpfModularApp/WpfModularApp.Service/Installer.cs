using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace WpfModularApp.Product
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.IConfigurationStore store)
        {
            container.Register(Component.For<Service.IProductRepository>()
                .ImplementedBy<Service.ProductRepository>());
        }
    }
}
