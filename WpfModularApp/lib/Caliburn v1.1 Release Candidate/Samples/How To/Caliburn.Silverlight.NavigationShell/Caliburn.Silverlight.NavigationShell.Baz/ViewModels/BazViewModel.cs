namespace Caliburn.Silverlight.NavigationShell.Baz.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using Framework.History;
    using Framework.Results;
    using PresentationFramework;
    using PresentationFramework.ApplicationModel;

    [HistoryKey("Baz", typeof(BazViewModel))]
    public class BazViewModel : Presenter
    {
        public IEnumerable<IResult> Save()
        {
            var dialog = new SaveFileDialog();
            yield return Show.Dialog(dialog);

            yield return Show.MessageBox("You saved " + dialog.SafeFileName + ".", "File");
        }

        public IEnumerable<IResult> Open()
        {
            var dialog = new OpenFileDialog();
            yield return Show.Dialog(dialog);

            yield return Show.MessageBox("You opened " + dialog.File.Name + ".", "File");
        }
    }
}