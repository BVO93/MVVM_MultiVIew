using MVVM_Mulitview.Data;
using MVVM_Mulitview.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Mulitview.Model;

namespace MVVM_Mulitview
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<SettingsViewModel>();

            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            services.AddTransient<IProductDataProvider, ProductDataProvider>();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var mainWindow = _serviceProvider.GetService<MainWindow>();
            // mainWindow?.Show();


            Settings setAtStartup = new Settings();
            setAtStartup.Location = "TesVersion";
            setAtStartup.TestVersion = true;

            // More simple option
            var mainWindow = new MainWindow(new MainViewModel(
               new CustomersViewModel(new CustomerDataProvider()),
               new ProductsViewModel(new ProductDataProvider()), 
               new SettingsViewModel())
               );

            mainWindow?.Show();
        }

    }
}