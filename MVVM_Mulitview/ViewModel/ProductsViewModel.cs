using MVVM_Mulitview.Data;
using MVVM_Mulitview.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;

            //Products.Add(new Product { Name = "Cappuccino", Description = "Espresso with milk and milk foam" });
        }

        public ObservableCollection<Product> Products { get; } = new();
        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await _productDataProvider.GetAllAsync();
            if (products is not null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }

        }

    }
}
