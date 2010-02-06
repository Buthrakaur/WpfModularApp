namespace Caliburn.Silverlight.NavigationShell.Framework.History
{
    using System;

    public interface IHistoryCoordinator
    {
        void Start(Action<HistoryConfiguration> configurator);
        void Refresh();
    }
}