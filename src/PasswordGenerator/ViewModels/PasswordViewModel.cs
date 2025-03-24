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

namespace PasswordGenerator.ViewModels
{
	public class PasswordViewModel : ViewModelBase
	{
		private Password _password;
		private RelayCommand _generatePasswordCommand;

		public PasswordViewModel()
		{
			_password = new Password();
			_generatePasswordCommand = new RelayCommand(execute => GeneratePassword(), canExecute => 
			{
				return (UseUppercase || UseLowercase || UseDigits || UseSpecialCharacters) &&
				(Length > 0);
			});
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

		public ICommand GeneratePasswordCommand => _generatePasswordCommand;

		public void GeneratePassword()
		{
			do {
				_password.GeneratePassword();
			}
			while (_password.HasTooManyDuplicatedChars(_password.GeneratedPassword) ||
			_password.HasDuplicatedNeighbourChars(_password.GeneratedPassword));
			
			this.OnPropertyChanged(nameof(GeneratedPassword));
		}
	}
}
