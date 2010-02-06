namespace Caliburn.Silverlight.NavigationShell.Framework.Services
{
    public interface ILoadScreen
    {
        void StartLoading(string message);
        void StopLoading();
    }
}