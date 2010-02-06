namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using System.Windows.Controls;
    using PresentationFramework;

    public class OpenDialogResult : IResult
    {
        private readonly OpenFileDialog _dialog;

        public OpenDialogResult(OpenFileDialog dialog)
        {
            _dialog = dialog;
        }

        public OpenFileDialog Dialog
        {
            get { return _dialog; }
        }

        public void Execute(IRoutedMessageWithOutcome message, IInteractionNode handlingNode)
        {
            var result = _dialog.ShowDialog().GetValueOrDefault(false);

            if(result)
                Completed(this, null);
            else Completed(this, new CancelResult());
        }

        public event Action<IResult, Exception> Completed = delegate { };
    }
}