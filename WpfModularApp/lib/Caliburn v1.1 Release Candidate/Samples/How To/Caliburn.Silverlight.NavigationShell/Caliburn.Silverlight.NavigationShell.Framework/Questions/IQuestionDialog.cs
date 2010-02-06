namespace Caliburn.Silverlight.NavigationShell.Framework.Questions
{
    using System.Collections.Generic;
    using PresentationFramework.ApplicationModel;

    public interface IQuestionDialog : IExtendedPresenter
    {
        void Setup(string caption, IEnumerable<Question> questions);
    }
}