using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WarehouseManager.Services;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //dbcontext here
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //services here
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(m => new MainWindow()
            {
                DataContext = m.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<ProductsTabViewModel>();
            services.AddSingleton<AvailabilityViewModel>();
            services.AddSingleton<DeliveryTabViewModel>();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();


            INavigationService homeNavigationService = HomeNavigationService();
            homeNavigationService.Navigate();


            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }

        private INavigationService HomeNavigationService()
        {
            return new NavigationService(_host.Services.GetRequiredService<NavigationStore>(),
                () => new HomePageViewModel(
                    _host.Services.GetRequiredService<ProductsTabViewModel>(),
                    _host.Services.GetRequiredService<AvailabilityViewModel>(),
                    _host.Services.GetRequiredService<DeliveryTabViewModel>()));

        }
    }
}
