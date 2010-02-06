using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Person.Service
{
    public interface IPersonQuery
    {
        IEnumerable<Model.Person> Query(string name, string city);
    }
}
