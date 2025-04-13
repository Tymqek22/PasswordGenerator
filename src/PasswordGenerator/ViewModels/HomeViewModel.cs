using PasswordGenerator.Commands;
using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordGenerator.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;

		public ICommand NavigateToGeneratorCommand { get; }
		public ICommand NavigateToAnalyzerCommand { get; }

		public HomeViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavigateToGeneratorCommand = new RelayCommand(execute => _navigationService.NavigateTo<GeneratorViewModel>());
			NavigateToAnalyzerCommand = new RelayCommand(execute => _navigationService.NavigateTo<GeneratorViewModel>());
		}
	}
}
