using PasswordGenerator.Commands;
using PasswordGenerator.Enums;
using PasswordGenerator.Models;
using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordGenerator.ViewModels
{
	public class AnalyzerViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly IPasswordValidatorService _validatorService;
		private readonly Password? _password = new();

		public ICommand NavigateToHomeCommand { get; }
		public ICommand NavigateToGeneratorCommand { get; }

		public AnalyzerViewModel(IPasswordValidatorService validatorService, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_validatorService = validatorService;
			_password.GeneratedPassword = "";

			NavigateToHomeCommand = new RelayCommand(execute => _navigationService.NavigateTo<HomeViewModel>());
			NavigateToGeneratorCommand = new RelayCommand(execute => _navigationService.NavigateTo<GeneratorViewModel>());
		}

		public string Password
		{
			get
			{
				return _password.GeneratedPassword;
			}
			set
			{
				_password.GeneratedPassword = value;

				if (Password != "") {
					this.CreatePasswordModel(Password);
					this.OnPropertyChanged(nameof(Password));
				}
			}
		}

		private int _strenghtScore;
		public int StrengthScore
		{
			get
			{
				return _strenghtScore;
			}
			set
			{
				_strenghtScore = value;
				this.OnPropertyChanged(nameof(StrengthScore));
			}
		}

		private string _strength;
		public string Strength
		{
			get
			{
				return _strength;
			}
			set
			{
				_strength = value;
				this.OnPropertyChanged(nameof(Strength));
			}
		}

		private void CreatePasswordModel(string password)
		{
			_password.Length = password.Length;
			_password.UseUppercase = _validatorService.HasUppercase(password);
			_password.UseLowercase = _validatorService.HasLowercase(password);
			_password.UseDigits = _validatorService.HasDigits(password);
			_password.UseSpecialCharacters = _validatorService.HasSpecialChars(password);

			StrengthScore = _validatorService.CalculateStrengthScore(password);
			Strength = _validatorService.CalculateStrength(StrengthScore);
		}
	}
}
