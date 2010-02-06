namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using PresentationFramework;
    using Services;

    public class LoadingResult : IResult
    {
        private readonly bool _show;
        private readonly string _message;

        public LoadingResult(bool show, string message)
        {
            _show = show;
            _message = message;
        }

        public void Execute(IRoutedMessageWithOutcome message, IInteractionNode handlingNode)
        {
            if(_show)
                ServiceLocator.Current.GetInstance<ILoadScreen>().StartLoading(_message);
            else ServiceLocator.Current.GetInstance<ILoadScreen>().StopLoading();

            Completed(this, null);
        }

        public event Action<IResult, Exception> Completed = delegate { };
    }
}