using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModularApp.Product.Service
{
    public interface IProductRepository
    {
        IEnumerable<Model.Product> GetAllProducts();
    }
}
