
using MVVM_Mulitview.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {


        public ObservableCollection<Product> Products { get; } = new();



        public ProductsViewModel()
        {
            Products.Add(new Product { Name = "Cake", Description = "Cake with fruit" });
            Products.Add(new Product { Name = "Pie", Description = "Apple Pie" });
        }





    }
}
