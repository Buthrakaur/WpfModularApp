using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Person.Model
{
    public class Person
    {
        private long lastId;
        public long Id { get; private set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        
        public Person()
        {
            lastId++;
            Id = lastId;
            Address = new Address();
        }
    }
}
