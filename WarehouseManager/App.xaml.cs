﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WarehouseManager.Data;
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
                    services.AddDbContext<ApplicationDatabaseContext>(options =>
                    {
                        options.UseSqlServer(context.Configuration.GetConnectionString("DatabaseServer"));
                    });
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //stores
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<CustomerStore>();
            services.AddSingleton<AddressStore>();
            services.AddSingleton<AvailabilityStore>();
            services.AddSingleton<ElementStore>();
            services.AddSingleton<DocumentStore>();
            services.AddSingleton<SectorStore>();
            services.AddSingleton<PackageStore>();

            //viewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(m => new MainWindow()
            {
                DataContext = m.GetRequiredService<MainViewModel>()
            });


            services.AddTransient<CustomerViewModel>(d => new CustomerViewModel(HomeNavigation(),
                _host.Services.GetRequiredService<CustomerStore>(),
                _host.Services.GetRequiredService<AddressStore>()
                ));
            services.AddTransient<CustomerTabViewModel>(d => new CustomerTabViewModel(NewCustomerNavigation(),
                _host.Services.GetRequiredService<CustomerStore>()
                ));
            services.AddTransient<AvailabilityViewModel>();
            services.AddTransient<WarehouseInfoTabViewModel>();

            services.AddTransient<LoginViewModel>(d => new LoginViewModel(HomeNavigation()));
            services.AddTransient<DeliveryViewModel>(d => new DeliveryViewModel(HomeNavigation(), 
                _host.Services.GetRequiredService<AddressStore>(),
                _host.Services.GetRequiredService<ElementStore>(),
                _host.Services.GetRequiredService<DocumentStore>(),
                _host.Services.GetRequiredService<PackageStore>(),
                _host.Services.GetRequiredService<CustomerStore>()
                ));
            services.AddTransient<DeliveryTabViewModel>(d => new DeliveryTabViewModel(NewDeliveryNavigation(),
                _host.Services.GetRequiredService<DocumentStore>(),
                _host.Services.GetRequiredService<CustomerStore>()
                ));

            services.AddTransient<HomePageViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();


            INavigationService homeNavigationService = StartupNavigation();
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

        private INavigationService StartupNavigation()
        {
            return new NavigationService(_host.Services.GetRequiredService<NavigationStore>(),
                () => _host.Services.GetRequiredService<LoginViewModel>());
        }

        private INavigationService HomeNavigation()
        {
            return new NavigationService(_host.Services.GetRequiredService<NavigationStore>(),
                () => _host.Services.GetRequiredService<HomePageViewModel>());
        }

        private INavigationService NewDeliveryNavigation()
        {
            return new NavigationService(_host.Services.GetRequiredService<NavigationStore>(),
                () => _host.Services.GetRequiredService<DeliveryViewModel>());
        }

        private INavigationService NewCustomerNavigation()
        {
            return new NavigationService(_host.Services.GetRequiredService<NavigationStore>(),
                () => _host.Services.GetRequiredService<CustomerViewModel>());
        }
    }
}
