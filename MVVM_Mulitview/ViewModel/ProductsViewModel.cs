using MVVM_Mulitview.Data;
using MVVM_Mulitview.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class ProductsViewModel: ViewModelBase
    {
        private readonly IProductDataProvider _productDataProvider;


        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }


        public ObservableCollection<Product> Products { get; } = new(); // ObservableCollection<Product>();

        public override async Task LoadAsync()
        {

             if(Products.Any())
            {
                return;
            }

            var products = await _productDataProvider.GetAllAsync();
            foreach(var product in products)
            {
                if(product.Name != null)
                    Products.Add(product);
            }


        }



    }
}
