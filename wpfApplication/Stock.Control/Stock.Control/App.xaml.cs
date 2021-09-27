using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stock.Control.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Stock.Control
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<StockDbContext>(options =>
            {
                options.UseSqlite("Data Source = Stock.db");
            });
            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();

           
        }
        private void OnStartup(object s, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
