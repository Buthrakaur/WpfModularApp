namespace Caliburn.Silverlight.NavigationShell.Shell.ViewModels
{
    using Framework.Services;
    using PresentationFramework.ApplicationModel;

    public class LoadScreenViewModel : Presenter, ILoadScreen
    {
        private readonly IWindowManager _windowManager;
        private string _message;
        private int _loadDepth;
        private readonly object _lock = new object();

        public LoadScreenViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange("Message");
            }
        }

        public void StartLoading(string message)
        {
            Message = string.IsNullOrEmpty(message)
                          ? "Loading..."
                          : message;

            lock(_lock)
            {
                _loadDepth++;

                if (_loadDepth == 1)
                    _windowManager.ShowDialog(this, null, null);
            }
        }

        public void StopLoading()
        {
            if(_loadDepth > 0)
            {
                lock(_lock)
                {
                    if(_loadDepth > 0)
                    {
                        _loadDepth--;

                        if(_loadDepth == 0)
                            Close();
                    }
                }
            }
        }
    }
}