using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Model.Product
{
    public class Product
    {
        private long LastId;
        public long Id { get; private set; }
        public string Name { get; set; }

        public Product()
        {
            LastId++;
            Id = LastId;
        }
    }
}
