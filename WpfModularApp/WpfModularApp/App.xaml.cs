using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Caliburn.PresentationFramework.ApplicationModel;
using Castle.Windsor;
using System.Reflection;
using System.IO;

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

        private Assembly[] LoadModules()
        {
            var directory = GetCurrentDirectory();

            Func<string, Assembly> getModuleAssembly = (file) => 
            {
                try
                {
                    return Assembly.LoadFile(file);
                }
                catch { }
                return null;
            };

            Func<Assembly, IWindsorInstaller> getInstaller = (asm) => {
                return
                (from t in asm.GetTypes()
                 where typeof(IWindsorInstaller).IsAssignableFrom(t)
                 select (IWindsorInstaller)Activator.CreateInstance(t)).FirstOrDefault();
            };

            var possibleModules =
                from file in Directory.GetFiles(directory, "WpfModularApp.*.dll")
                let asm = getModuleAssembly(file)
                where asm != null
                select asm;

            var installers =
                from m in possibleModules
                let i = getInstaller(m)
                where i != null
                select i;

            container.Install(installers.ToArray());

            return (from i in installers
                    select i.GetType().Assembly).Distinct().ToArray();
        }

        private static string GetCurrentDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var directory = Path.GetDirectoryName(path);
            return directory;
        }

        protected override System.Reflection.Assembly[] SelectAssemblies()
        {
            var modules = LoadModules();
            return base.SelectAssemblies()
                .Concat(modules)
                .ToArray();
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
