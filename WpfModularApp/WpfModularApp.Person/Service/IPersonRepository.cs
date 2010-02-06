using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Person.Service
{
    public interface IPersonRepository
    {
        IEnumerable<Model.Person> GetAllPerson();
    }
}
