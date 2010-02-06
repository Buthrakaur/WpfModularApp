namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using PresentationFramework.ApplicationModel;

    public static class ExtensionMethods
    {
        public static IOpenResult<TChild> ConfigureChild<TChild>(this IOpenResult<TChild> result, Action<TChild> configure)
            where TChild : IPresenter, ILifecycleNotifier
        {
            result.OnConfigure = configure;
            return result;
        }

        public static IOpenResult<TChild> WhenShuttingDown<TChild>(this IOpenResult<TChild> result, Action<TChild> onShutdown)
            where TChild : IPresenter, ILifecycleNotifier
        {
            result.OnShutDown = onShutdown;
            return result;
        }

        public static IOpenResult<TChild> WithData<TChild, TData>(this IOpenResult<TChild> result, TData data)
            where TChild : IPresenter, ILifecycleNotifier, IDataCentric<TData>
        {
            result.SetData(data);
            return result;
        }
    }
}