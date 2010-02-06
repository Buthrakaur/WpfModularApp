namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using System.IO;
    using System.Net;
    using PresentationFramework;

    public class WebClientResult  : IResult
    {
        private readonly Uri _uri;

        public WebClientResult(Uri uri)
        {
            _uri = uri;
        }

        public Uri Uri
        {
            get { return _uri; }
        }

        public Stream Stream { get; set; }

        public void Execute(IRoutedMessageWithOutcome message, IInteractionNode handlingNode)
        {
            var client = new WebClient();

            client.OpenReadCompleted += (s, e) =>{
                if(e.Error != null)
                    Core.Invocation.Execute.OnUIThread(() => Completed(this, e.Error));
                else
                {
                    Stream = e.Result;
                    Core.Invocation.Execute.OnUIThread(() => Completed(this, null));
                }
            };

            client.OpenReadAsync(_uri);
        }

        public event Action<IResult, Exception> Completed = delegate { };
    }
}