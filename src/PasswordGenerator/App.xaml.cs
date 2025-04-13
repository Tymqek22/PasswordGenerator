using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System;
using PasswordGenerator.Services.Interfaces;
using PasswordGenerator.Services;
using PasswordGenerator.ViewModels;
using PasswordGenerator.Stores;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

		public App()
		{
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
		}

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPasswordGeneratorService,PasswordGeneratorService>();
            services.AddSingleton<IPasswordValidatorService,PasswordValidatorService>();
            services.AddScoped<IFileReader,FileReader>();

			services.AddSingleton<NavigationStore>();
			services.AddSingleton<MainViewModel>();
			services.AddSingleton<MainWindow>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<GeneratorViewModel>();
			services.AddTransient<AnalyzerViewModel>();

			services.AddSingleton<INavigationService,NavigationService>();

			services.AddSingleton<Func<Type,ViewModelBase>>(sp => type =>
				(ViewModelBase)sp.GetRequiredService(type));
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
			navigationService.NavigateTo<HomeViewModel>();

			var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();

			base.OnStartup(e);
		}
	}

}
