namespace Caliburn.Silverlight.NavigationShell.Bar.ViewModels
{
    using Framework;
    using Framework.History;
    using Framework.Questions;
    using PresentationFramework.ApplicationModel;

    [HistoryKey("Bar", typeof(BarViewModel))]
    public class BarViewModel : Presenter, ISupportCustomShutdown, IDataCentric<string>
    {
        private string _message = "This is the Bar View.";

        public string Message
        {
            get { return _message; }
            set { _message = value; NotifyOfPropertyChange("Message"); }
        }

        public void LoadData(string data)
        {
            Message = data;
        }

        public override bool CanShutdown()
        {
            return false;
        }

        public ISubordinate CreateShutdownModel()
        {
            return new Question(this, "Are you sure you want to navigate away from this page?", Answer.Yes, Answer.No);
        }

        public bool CanShutdown(ISubordinate shutdownModel)
        {
            var question = (Question)shutdownModel;
            return question.Answer == Answer.Yes;
        }
    }
}