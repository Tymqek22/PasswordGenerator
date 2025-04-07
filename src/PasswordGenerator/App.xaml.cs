using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System;
using PasswordGenerator.Services.Interfaces;
using PasswordGenerator.Services;
using PasswordGenerator.ViewModels;

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

            services.AddSingleton<MainWindow>();
            services.AddSingleton<PasswordViewModel>();
        }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();
		}
	}

}
