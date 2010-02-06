namespace Caliburn.Silverlight.NavigationShell.Framework.Controls
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using PresentationFramework;

    public class DialogChrome : ChildWindow
    {
        public static DependencyProperty ButtonsProperty =
            DependencyProperty.Register(
                "Buttons",
                typeof(IObservableCollection<ButtonModel>),
                typeof(DialogChrome),
                null
                );

        public DialogChrome()
        {
            DefaultStyleKey = typeof(DialogChrome);
        }

        [TypeConverter(typeof(ButtonConverter))]
        public IObservableCollection<ButtonModel> Buttons
        {
            get { return GetValue(ButtonsProperty) as IObservableCollection<ButtonModel>; }
            set { SetValue(ButtonsProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var chrome = GetTemplateChild("Chrome") as UIElement;
            if (chrome != null && Title == null) chrome.Visibility = Visibility.Collapsed;
        }
    }
}