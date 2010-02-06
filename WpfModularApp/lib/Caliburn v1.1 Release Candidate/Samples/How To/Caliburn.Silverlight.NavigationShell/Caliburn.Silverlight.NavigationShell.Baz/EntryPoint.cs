namespace Caliburn.Silverlight.NavigationShell.Baz
{
    using System.Collections.Generic;
    using Framework;
    using Framework.Results;
    using Framework.Services;
    using PresentationFramework;
    using ViewModels;

    public class EntryPoint : IEntryPoint
    {
        public IEnumerable<IResult> Enter()
        {
            yield return Show.Child<BazViewModel>()
                .In<IShell>();
        }
    }
}