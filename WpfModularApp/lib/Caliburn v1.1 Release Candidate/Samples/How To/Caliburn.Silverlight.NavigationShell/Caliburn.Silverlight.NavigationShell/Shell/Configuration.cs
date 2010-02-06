namespace Caliburn.Silverlight.NavigationShell.Shell
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Core;
    using Framework;
    using Framework.History;
    using Framework.Questions;
    using Framework.Services;
    using PresentationFramework.ApplicationModel;
    using ViewModels;

    public class Configuration : ModuleBase
    {
        public Configuration(IConfigurationHook hook)
            : base(hook) {}

        protected override IEnumerable<ComponentInfo> GetComponents()
        {
            yield return PerRequest<IHistoryCoordinator, HistoryCoordinator>();
            yield return PerRequest<IQuestionDialog, QuestionDialogViewModel>();
            yield return Singleton<IResourceManager, ResourceManager>();
            yield return Singleton<IStateManager, DeepLinkStateManager>();
            yield return Singleton<IShell, ShellViewModel>();
            yield return Singleton<IWindowManager, DefaultWindowManager>();
            yield return Singleton<ILoadScreen, LoadScreenViewModel>();

            var moduleTypes = from type in Assembly.GetExecutingAssembly().GetExportedTypes()
                              where typeof(ITaskBarItem).IsAssignableFrom(type)
                                    && !type.IsAbstract && !type.IsInterface
                                    && !typeof(LazyTaskBarItem).IsAssignableFrom(type)
                              select type;

            foreach(var type in moduleTypes)
            {
                yield return Singleton(typeof(ITaskBarItem), type, type.FullName);
            }
        }
    }
}