using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Person.Service
{
    public class PersonRepository: IPersonRepository
    {
        private readonly List<Model.Person> people = new List<Model.Person>();

        public PersonRepository()
        {
            for (var i = 1; i <= 100; i++)
            {
                people.Add(new Model.Person()
                {
                    Name = "person " + i,
                    Address = new Model.Address { City = "city " + i, Street = "street " + i }
                });
            }
        }

        public IEnumerable<Model.Person> GetAllPerson()
        {
            return people.AsReadOnly();
        }
    }
}
