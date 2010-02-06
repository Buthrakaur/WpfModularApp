namespace Caliburn.Silverlight.NavigationShell.Baz
{
    using System.Collections.Generic;
    using Core;
    using Framework;

    public class Configuration : ModuleBase
    {
        public Configuration(IConfigurationHook hook)
            : base(hook) {}

        protected override IEnumerable<ComponentInfo> GetComponents()
        {
            //You could add some module specific components here
            return base.GetComponents();
        }

        protected override void Initialize()
        {
            //You could add some module specific initialization here
            base.Initialize();
        }
    }
}