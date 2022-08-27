using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static MVVM_Mulitview.ViewModel.CustomersViewModel;

namespace MVVM_Mulitview.Converter
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var navigationSide = (NavigationSide)value;
            return navigationSide == NavigationSide.Left
                ? 0  // Value for grid column. If left 0 is returned. Else 2 is returned.
                : 2;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}