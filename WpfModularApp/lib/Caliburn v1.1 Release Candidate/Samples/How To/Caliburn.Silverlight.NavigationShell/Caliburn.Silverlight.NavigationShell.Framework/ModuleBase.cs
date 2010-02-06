namespace Caliburn.Silverlight.NavigationShell.Framework
{
    using System;
    using System.Collections.Generic;
    using Core;

    public abstract class ModuleBase : CaliburnModule
    {
        protected ModuleBase(IConfigurationHook hook)
            : base(hook) {}

        protected override IEnumerable<ComponentInfo> GetComponents()
        {
            yield break;
        }

        protected override void Initialize()
        {
        }

        protected ComponentInfo Singleton<TFrom, TTo>()
            where TTo : TFrom
        {
            return Singleton(typeof(TFrom), typeof(TTo));
        }

        protected ComponentInfo PerRequest<TFrom, TTo>()
            where TTo : TFrom
        {
            return PerRequest(typeof(TFrom), typeof(TTo));
        }

        protected ComponentInfo Singleton(Type from, Type to, string key)
        {
            return new ComponentInfo
            {
                Service = from,
                Implementation = to,
                Key = key,
                Lifetime = ComponentLifetime.Singleton
            };
        }
    }
}