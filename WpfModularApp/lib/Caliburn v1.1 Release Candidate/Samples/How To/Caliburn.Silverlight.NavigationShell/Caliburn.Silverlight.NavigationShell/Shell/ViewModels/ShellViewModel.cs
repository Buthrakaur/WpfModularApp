namespace Caliburn.Silverlight.NavigationShell.Shell.ViewModels
{
    using System;
    using System.Linq;
    using Framework;
    using Framework.History;
    using Framework.Questions;
    using Framework.Results;
    using Framework.Services;
    using PresentationFramework;
    using PresentationFramework.ApplicationModel;

    public class ShellViewModel : PresenterManager, IShell
    {
        private readonly IHistoryCoordinator _historyCoordinator;
        private readonly IObservableCollection<ITaskBarItem> _taskBarItems;

        public ShellViewModel(IHistoryCoordinator historyCoordinator, ITaskBarItem[] taskBarItems)
        {
            _historyCoordinator = historyCoordinator;
            _taskBarItems = new BindableCollection<ITaskBarItem>(taskBarItems);
        }

        public IObservableCollection<ITaskBarItem> TaskBarItems
        {
            get { return _taskBarItems; }
        }

        protected override void OnInitialize()
        {
            _historyCoordinator.Start(
                config =>{
                    config.Host = this;
                    config.HistoryKey = "Page";
                    config.PresenterNotFound = HandlePresenterNotFound;
                });

            base.OnInitialize();
        }

        protected override void OnActivate()
        {
            Execute(TaskBarItems.First().Enter());
            base.OnActivate();
        }

        private void HandlePresenterNotFound(string historyKey)
        {
            if(string.IsNullOrEmpty(historyKey))
                return;

            var item = TaskBarItems
                .FirstOrDefault(x => x.DisplayName == historyKey);

            if (item != null)
                Execute(item.Enter());
            else Execute(Show.MessageBox("Invalid Query String Parameter: " + historyKey));
        }

        protected override void ExecuteShutdownModel(ISubordinate model, Action completed)
        {
            model.Execute(completed);
        }
    }
}