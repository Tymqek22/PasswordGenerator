using PasswordGenerator.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerator.Models;
using System.Windows.Input;
using System.Windows.Navigation;
using PasswordGenerator.Services.Interfaces;

namespace PasswordGenerator.ViewModels
{
	public class GeneratorViewModel : ViewModelBase
	{
		private readonly IPasswordGeneratorService _passwordGeneratorService;
		private readonly INavigationService _navigationService;
		private Password _password;

		public ICommand GeneratePasswordCommand { get; }
		public ICommand NavigateToHomeCommand { get; }
		public ICommand NavigateToAnalyzerCommand { get; }

		public GeneratorViewModel(IPasswordGeneratorService passwordGeneratorService, 
			IPasswordValidatorService passwordValidatorService, INavigationService navigationService)
		{
			_passwordGeneratorService = passwordGeneratorService;
			_navigationService = navigationService;

			_password = new Password();
			GeneratePasswordCommand = new RelayCommand(execute => GeneratePassword(), canExecute => 
			{
				return (UseUppercase || UseLowercase || UseDigits || UseSpecialCharacters) &&
				(Length >= 8  && Length <= 50);
			});

			NavigateToHomeCommand = new RelayCommand(execute => _navigationService.NavigateTo<HomeViewModel>());
			NavigateToAnalyzerCommand = new RelayCommand(execute => _navigationService.NavigateTo<AnalyzerViewModel>());
		}

		public int Length
		{
			get 
			{ 
				return _password.Length; 
			}
			set 
			{ 
				_password.Length = value; 
				this.OnPropertyChanged(nameof(Length));
				CommandManager.InvalidateRequerySuggested();
			}
		}

		public bool UseUppercase
		{
			get 
			{ 
				return _password.UseUppercase; 
			}
			set 
			{ 
				_password.UseUppercase = value; 
				this.OnPropertyChanged(nameof(UseUppercase));
				CommandManager.InvalidateRequerySuggested();
			}
		}

		public bool UseLowercase
		{
			get 
			{ 
				return _password.UseLowercase; 
			}
			set 
			{ 
				_password.UseLowercase = value; 
				this.OnPropertyChanged(nameof(UseLowercase));
				CommandManager.InvalidateRequerySuggested();
			}
		}

		public bool UseDigits
		{
			get 
			{ 
				return _password.UseDigits; 
			}
			set 
			{ 
				_password.UseDigits = value; 
				this.OnPropertyChanged(nameof(UseDigits));
				CommandManager.InvalidateRequerySuggested();
			}
		}

		public bool UseSpecialCharacters
		{
			get 
			{ 
				return _password.UseSpecialCharacters; 
			}
			set 
			{ 
				_password.UseSpecialCharacters = value; 
				this.OnPropertyChanged(nameof(UseSpecialCharacters));
				CommandManager.InvalidateRequerySuggested();
			}
		}

		public string? GeneratedPassword
		{
			get 
			{ 
				return _password.GeneratedPassword; 
			}
			private set 
			{
				_password.GeneratedPassword = value; 
				this.OnPropertyChanged(nameof(GeneratedPassword)); 
			}
		}

		public void GeneratePassword()
		{
			_password.GeneratedPassword = _passwordGeneratorService.GenerateValidPassword(_password);
			
			this.OnPropertyChanged(nameof(GeneratedPassword));
		}
	}
}
