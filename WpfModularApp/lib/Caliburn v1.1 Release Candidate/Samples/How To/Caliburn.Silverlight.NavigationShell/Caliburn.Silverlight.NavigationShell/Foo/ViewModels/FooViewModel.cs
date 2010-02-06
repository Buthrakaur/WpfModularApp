namespace Caliburn.Silverlight.NavigationShell.Foo.ViewModels
{
    using System.Collections.Generic;
    using Framework.History;
    using Framework.Results;
    using PresentationFramework;
    using PresentationFramework.ApplicationModel;

    [HistoryKey("Foo", typeof(FooViewModel))]
    public class FooViewModel : Presenter
    {
        public IEnumerable<IResult> ClickMe()
        {
            yield return Show.MessageBox(
                "This is a message from me to you! It's happening asynchronously.  Take a look at the FooViewModel."
                );

            yield return Show.MessageBox(
                "This is another asynchronous message.  Pretty neat how you can write these synchronously."
                );

            yield return Show.MessageBox(
                "Just imagine how much easier it would be to handle web services and loaders with this technique."
                );
        }
    }
}