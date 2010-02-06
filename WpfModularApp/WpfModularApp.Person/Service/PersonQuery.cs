using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Person.Service
{
    public class PersonQuery: IPersonQuery
    {
        private readonly IPersonRepository personRepo;

        public PersonQuery(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        public IEnumerable<Model.Person> Query(string name, string city)
        {
            return (from p in personRepo.GetAllPerson()
                    where (string.IsNullOrEmpty(name) || p.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)) &&
                          (string.IsNullOrEmpty(city) || p.Address.City.StartsWith(city, StringComparison.InvariantCultureIgnoreCase))
                    select p);
        }
    }
}
