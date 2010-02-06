namespace Caliburn.Silverlight.NavigationShell.Framework.History
{
    using PresentationFramework.ApplicationModel;

    public interface IHistoryKey
    {
        string Value { get; }
        IPresenter GetInstance();
    }
}