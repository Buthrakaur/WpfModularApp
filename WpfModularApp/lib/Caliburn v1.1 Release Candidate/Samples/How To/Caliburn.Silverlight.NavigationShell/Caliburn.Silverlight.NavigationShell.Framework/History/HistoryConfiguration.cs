namespace Caliburn.Silverlight.NavigationShell.Framework.History
{
    using System;
    using PresentationFramework.ApplicationModel;

    public class HistoryConfiguration
    {
        public HistoryConfiguration()
        {
            StateName = "Default";
            AlterTitle = (oldTitle, presenter) => presenter.DisplayName;
            PresenterNotFound = delegate { };
        }

        public string StateName { get; set; }
        public IPresenterManager Host { get; set; }
        public string HistoryKey { get; set; }
        public Func<string, IPresenter> DeterminePresenter { get; set; }
        public Func<string, IPresenter, string> AlterTitle { get; set; }
        public Action<string> PresenterNotFound { get; set; }
    }
}