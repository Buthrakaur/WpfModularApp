namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using System.Windows.Controls;
    using PresentationFramework.ApplicationModel;
    using Questions;

    public static class Show
    {
        public static OpenChildResult<TChild> Child<TChild>()
            where TChild : IExtendedPresenter
        {
            return new OpenChildResult<TChild>();
        }

        public static OpenChildResult<TChild> Child<TChild>(TChild child)
            where TChild : IExtendedPresenter
        {
            return new OpenChildResult<TChild>(child);
        }

        public static OpenModalResult<TModal> Modal<TModal>()
            where TModal : IExtendedPresenter
        {
            return new OpenModalResult<TModal>();
        }

        public static OpenModalResult<TModal> Modal<TModal>(TModal modal)
            where TModal : IExtendedPresenter
        {
            return new OpenModalResult<TModal>(modal);
        }

        public static SaveDialogResult Dialog(SaveFileDialog dialog)
        {
            return new SaveDialogResult(dialog);
        }

        public static OpenDialogResult Dialog(OpenFileDialog dialog)
        {
            return new OpenDialogResult(dialog); 
        }

        public static LoadingResult Loader()
        {
            return new LoadingResult(true, "Loading...");
        }

        public static LoadingResult Loader(string message)
        {
            return new LoadingResult(true, message);
        }

        public static LoadingResult NoLoader()
        {
            return new LoadingResult(false, null);
        }

        public static PlayAnimation Animation(string animationKey)
        {
            return new PlayAnimation(animationKey);
        }

        public static MessageBoxResult MessageBox(string text)
        {
            return new MessageBoxResult(text);
        }

        public static MessageBoxResult MessageBox(string text, string caption)
        {
            return new MessageBoxResult(text, caption);
        }

        public static MessageBoxResult MessageBox(string text, string caption, Action<Answer> handleResult)
        {
            return new MessageBoxResult(text, caption, handleResult);
        }

        public static MessageBoxResult MessageBox(string text, string caption, Action<Answer> handleResult, params Answer[] possibleAnswers)
        {
            return new MessageBoxResult(text, caption, handleResult, possibleAnswers);
        }
    }
}