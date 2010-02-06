using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.ApplicationModel;

namespace WpfModularApp.ViewModels
{
    public class ShellViewModel: MultiPresenter
    {
        public ShellViewModel(params IPresenter[] presenters)
        {
            presenters.ToList().ForEach(Presenters.Add);
        }
    }
}
