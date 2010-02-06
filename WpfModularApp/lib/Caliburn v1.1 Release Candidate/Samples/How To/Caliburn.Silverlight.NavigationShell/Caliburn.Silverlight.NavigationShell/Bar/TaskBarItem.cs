namespace Caliburn.Silverlight.NavigationShell.Bar
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Media.Imaging;
    using Framework;
    using Framework.Results;
    using Framework.Services;
    using PresentationFramework;
    using ViewModels;

    public class TaskBarItem : ITaskBarItem
    {
        private readonly IResourceManager _resourceManager;

        public TaskBarItem(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public BitmapImage Icon
        {
            get { return _resourceManager.GetBitmap("Bar/Resources/BarIcon.png", Assembly.GetExecutingAssembly().GetAssemblyName()); }
        }

        public string DisplayName
        {
            get { return "Bar"; }
        }

        public IEnumerable<IResult> Enter()
        {
            yield return Show.Child<BarViewModel>()
                .In<IShell>()
                .WithData("Hello from Bar!");
        }
    }
}