namespace Caliburn.Silverlight.NavigationShell.Framework.History
{
    using System;
    using System.Linq;
    using PresentationFramework.ApplicationModel;

    public static class ExtensionMethods
    {
        public static string GetHistoryValue(this IPresenter presenter)
        {
            var keyAttribute = presenter.GetHistoryKey();
            return keyAttribute != null ? keyAttribute.Value : null;
        }

        public static IHistoryKey GetHistoryKey(this IPresenter presenter)
        {
            return presenter == null ? null : presenter.GetType().GetHistoryKey();
        }

        public static IHistoryKey GetHistoryKey(this Type type)
        {
            return type
                .GetCustomAttributes(false)
                .OfType<IHistoryKey>()
                .FirstOrDefault();
        }
    }
}