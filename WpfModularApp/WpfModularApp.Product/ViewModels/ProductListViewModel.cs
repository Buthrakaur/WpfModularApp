using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.Core.Metadata;
using System.ComponentModel;

namespace WpfModularApp.Product.ViewModels
{
    [PerRequest(typeof(IPresenter))]
    public class ProductListViewModel: Presenter
    {
        private readonly Service.IProductRepository productRepo;

        public ProductListViewModel(Service.IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }

        private BindingList<Model.Product> products = new BindingList<Model.Product>();
        public BindingList<Model.Product> Products
        {
            get { return products; }
        }

        public override void Activate()
        {
            base.Activate();

            Products.Clear();
            productRepo.GetAllProducts().ToList().ForEach(Products.Add);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            Products.Clear();
        }
    }
}
