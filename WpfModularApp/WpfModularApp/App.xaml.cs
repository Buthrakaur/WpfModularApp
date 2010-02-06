using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Caliburn.PresentationFramework.ApplicationModel;
using Castle.Windsor;
using System.Reflection;

namespace WpfModularApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : CaliburnApplication
    {
        private readonly IWindsorContainer container = new WindsorContainer();

        protected override Microsoft.Practices.ServiceLocation.IServiceLocator CreateContainer()
        {
            return new Caliburn.Castle.WindsorAdapter(container);
        }

        protected override System.Reflection.Assembly[] SelectAssemblies()
        {
            return base.SelectAssemblies();
        }

        protected override object CreateRootModel()
        {
            var binder = (DefaultBinder)Container.GetInstance<IBinder>();
            binder.EnableMessageConventions();
            binder.EnableBindingConventions();
            
            return base.CreateRootModel();
        }
    }
}
