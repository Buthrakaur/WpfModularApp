using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.ApplicationModel;
using WpfModularApp.Person.Model;
using WpfModularApp.Person.Service;
using System.ComponentModel;
using Caliburn.PresentationFramework.Filters;
using Caliburn.Core.Metadata;

namespace WpfModularApp.Person.ViewModels
{
    [PerRequest(typeof(PersonListViewModel))]
    public class PersonListViewModel: Presenter
    {
        private readonly IPersonQuery personQuery;

        public PersonListViewModel(IPersonQuery qry)
        {
            personQuery = qry;
        }

        private BindingList<Model.Person> people = new BindingList<Model.Person>();
        public BindingList<Model.Person> People
        {
            get { return people; }
        }

        private string filterCity;
        public string FilterCity
        {
            get { return filterCity; }
            set
            {
                filterCity = value;
                NotifyOfPropertyChange("FilterCity");
            }
        }

        private string filterName;
        public string FilterName
        {
            get { return filterName; }
            set
            {
                filterName = value;
                NotifyOfPropertyChange("FilterName");
            }
        }

        [Dependencies("FilterName", "FilterCity")]
        public void ExecuteFilter()
        {
            People.Clear();
            personQuery.Query(FilterName, FilterCity).ToList().ForEach(People.Add);
        }
    }
}
