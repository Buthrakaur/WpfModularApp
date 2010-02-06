namespace Caliburn.Silverlight.NavigationShell.Framework.Questions
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using PresentationFramework;
    using PresentationFramework.ApplicationModel;

    public class Question : PropertyChangedBase, ISubordinate
    {
        private Answer _answer = Answer.No;

        public Question(IPresenter master, string text)
            : this(master, text, Answer.No, Answer.Yes, Answer.Cancel) { }

        public Question(IPresenter master, string text, params Answer[] possibleAnswers)
        {
            Master = master;
            Text = text;
            PossibleAnswers = new BindableEnumCollection<Answer>(possibleAnswers);
            Buttons = ConvertToButtons(possibleAnswers);
        }

        public IPresenter Master { get; private set; }
        public string Text { get; private set; }
        public BindableEnumCollection<Answer> PossibleAnswers { get; set; }
        public IObservableCollection<ButtonModel> Buttons { get; set; }

        public Answer Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                NotifyOfPropertyChange("Answer");
            }
        }

        private BindableCollection<ButtonModel> ConvertToButtons(IEnumerable<Answer> possibleAnswers)
        {
            if (possibleAnswers.Contains(Answer.Yes))
            {
                return possibleAnswers.Contains(Answer.Cancel)
                           ? new BindableCollection<ButtonModel> { new ButtonModel("Yes"), new ButtonModel("No"), new ButtonModel("Cancel") }
                           : new BindableCollection<ButtonModel> { new ButtonModel("Yes"), new ButtonModel("No") };
            }

            return possibleAnswers.Contains(Answer.Cancel)
                       ? new BindableCollection<ButtonModel> { new ButtonModel("Ok"), new ButtonModel("Cancel") }
                       : new BindableCollection<ButtonModel> { new ButtonModel("Ok") };
        }
    }
}