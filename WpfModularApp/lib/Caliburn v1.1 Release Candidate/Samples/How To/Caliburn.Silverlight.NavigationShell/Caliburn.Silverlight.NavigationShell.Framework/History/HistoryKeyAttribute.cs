namespace Caliburn.Silverlight.NavigationShell.Framework.History
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using PresentationFramework.ApplicationModel;

    public class HistoryKeyAttribute : Attribute, IHistoryKey
    {
        private readonly Type _type;
        private readonly string _value;

        public HistoryKeyAttribute(string value, Type type)
        {
            _value = value;
            _type = type;
        }

        public string Value
        {
            get { return _value; }
        }

        public IPresenter GetInstance()
        {
            return (IPresenter)ServiceLocator.Current.GetInstance(_type);
        }
    }
}