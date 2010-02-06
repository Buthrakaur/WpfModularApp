using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Product.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Model.Product> products = new List<Model.Product>();

        public ProductRepository()
        {
            for (var i = 1; i <= 100; i++)
            {
                products.Add(new Model.Product(){Name = "product " + i.ToString()});
            }
        }

        public IEnumerable<Model.Product> GetAllProducts()
        {
            return products.AsReadOnly();
        }
    }
}
