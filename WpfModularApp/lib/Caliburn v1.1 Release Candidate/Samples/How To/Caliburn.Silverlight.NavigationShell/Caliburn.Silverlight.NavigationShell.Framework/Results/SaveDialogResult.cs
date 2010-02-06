namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using System.Windows.Controls;
    using PresentationFramework;

    public class SaveDialogResult : IResult
    {
        private readonly SaveFileDialog _dialog;

        public SaveDialogResult(SaveFileDialog dialog)
        {
            _dialog = dialog;
        }

        public SaveFileDialog Dialog
        {
            get { return _dialog; }
        }

        public void Execute(IRoutedMessageWithOutcome message, IInteractionNode handlingNode)
        {
            var result = _dialog.ShowDialog().GetValueOrDefault(false);

            if (result)
                Completed(this, null);
            else Completed(this, new CancelResult());
        }

        public event Action<IResult, Exception> Completed = delegate { };
    }
}