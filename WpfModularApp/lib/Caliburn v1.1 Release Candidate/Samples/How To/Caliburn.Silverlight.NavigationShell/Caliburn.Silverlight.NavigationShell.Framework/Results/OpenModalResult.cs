namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using PresentationFramework;
    using PresentationFramework.ApplicationModel;
    using Services;

    public class OpenModalResult<TModal> : OpenResultBase<TModal>
        where TModal : IExtendedPresenter
    {
        private readonly Func<TModal> _locateModal = () => ServiceLocator.Current.GetInstance<TModal>();

        public OpenModalResult() { }

        public OpenModalResult(TModal child)
        {
            _locateModal = () => child;
        }

        public override void Execute(IRoutedMessageWithOutcome message, IInteractionNode handlingNode)
        {
            var dialogManager = ServiceLocator.Current.GetInstance<IWindowManager>();
            var child = _locateModal();

            if(_setData != null)
                _setData(child);

            if(_onConfigure != null)
                _onConfigure(child);

            child.WasShutdown +=
                (s, e) =>{
                    if(_onShutDown != null)
                        _onShutDown(child);

                    OnCompleted(null);
                };

            dialogManager.ShowDialog(child, null, null);
        }
    }
}