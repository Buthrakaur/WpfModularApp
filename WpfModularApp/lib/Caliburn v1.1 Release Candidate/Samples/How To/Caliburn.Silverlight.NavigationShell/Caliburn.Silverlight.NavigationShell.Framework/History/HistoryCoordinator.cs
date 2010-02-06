namespace Caliburn.Silverlight.NavigationShell.Framework.History
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Browser;
    using Core;
    using PresentationFramework.ApplicationModel;

    public class HistoryCoordinator : IHistoryCoordinator
    {
        private readonly IStateManager _stateManager;
        private readonly IAssemblySource _assemblySource;

        private HistoryConfiguration _config;
        private IPresenter _previousPresenter;
        private IList<IHistoryKey> _historyKeys;

        public HistoryCoordinator(IStateManager stateManager, IAssemblySource assemblySource)
        {
            _stateManager = stateManager;
            _assemblySource = assemblySource;
        }

        public void Start(Action<HistoryConfiguration> configurator)
        {
            _historyKeys = _assemblySource.SelectMany(assembly => FindKeys(assembly)).ToList();
            _assemblySource.AssemblyAdded += assembly => FindKeys(assembly).Apply(x => _historyKeys.Add(x));

            _config = new HistoryConfiguration
            {
                DeterminePresenter = value =>{
                    var key = _historyKeys.FirstOrDefault(x => x.Value == value);
                    return key != null
                               ? key.GetInstance()
                               : null;
                }
            };

            configurator(_config);

            _config.Host.PropertyChanged += Host_PropertyChanged;
            _stateManager.AfterStateLoad += OnAfterStateLoad;
            _stateManager.Initialize(_config.StateName);
        }

        public void Refresh()
        {
            var historyValue = _stateManager.Get(_config.HistoryKey);
            var presenter = _config.DeterminePresenter(historyValue);

            if(presenter == null)
                _config.PresenterNotFound(historyValue);
            else if(_config.Host.CurrentPresenter == presenter) return;
            else
            {
                _config.Host.Open(presenter, wasSuccess =>{
                    if(wasSuccess)
                        UpdateTitle(presenter);
                    else if(_previousPresenter != null)
                    {
                        _stateManager.InsertOrUpdate(_config.HistoryKey, _previousPresenter.GetHistoryValue());
                        _stateManager.CommitChanges(_previousPresenter.DisplayName);
                        UpdateTitle(_previousPresenter);
                    }
                });
            }
        }

        private void UpdateTitle(IPresenter presenter)
        {
            var oldTitle = HtmlPage.Document.GetProperty("title");
            var newTitle = _config.AlterTitle(oldTitle.ToString(), presenter);

            if (!string.IsNullOrEmpty(newTitle))
                HtmlPage.Document.SetProperty("title", newTitle);
        }

        private IEnumerable<IHistoryKey> FindKeys(Assembly assembly)
        {
            return from type in assembly.GetExportedTypes()
                   let key = type.GetHistoryKey()
                   where key != null
                   select key;
        }

        private void Host_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "CurrentPresenter") return;

            if (_config.Host.CurrentPresenter == _previousPresenter)
                return;

            _previousPresenter = _config.Host.CurrentPresenter;

            if (_previousPresenter == null)
                _stateManager.Remove(_config.HistoryKey);
            else
            {
                _stateManager.InsertOrUpdate(_config.HistoryKey, _previousPresenter.GetHistoryValue());
                _stateManager.CommitChanges(_previousPresenter.DisplayName);

                UpdateTitle(_previousPresenter);
            }
        }

        private void OnAfterStateLoad(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}