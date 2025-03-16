using Domain;
using PasswordGenerator.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordGenerator.ViewModels
{
	public class PasswordViewModel : INotifyPropertyChanged
	{
		private Password _password;

		public PasswordViewModel()
		{
			_password = new Password();
			GeneratePasswordCommand = new RelayCommand(GeneratePassword, () => true);
		}

		public int Length
		{
			get { return _password.Length; }
			set 
			{ 
				_password.Length = value; 
				this.OnPropertyChanged(nameof(Length)); 
			}
		}

		public bool UseUppercase
		{
			get { return _password.UseUppercase; }
			set 
			{ 
				_password.UseUppercase = value; 
				this.OnPropertyChanged(nameof(UseUppercase)); 
			}
		}

		public bool UseLowercase
		{
			get { return _password.UseLowercase; }
			set 
			{ 
				_password.UseLowercase = value; 
				this.OnPropertyChanged(nameof(UseLowercase)); 
			}
		}

		public bool UseDigits
		{
			get { return _password.UseDigits; }
			set 
			{ 
				_password.UseDigits = value; 
				this.OnPropertyChanged(nameof(UseDigits)); 
			}
		}

		public bool UseSpecialCharacters
		{
			get { return _password.UseSpecialCharacters; }
			set 
			{ 
				_password.UseSpecialCharacters = value; 
				this.OnPropertyChanged(nameof(UseSpecialCharacters)); 
			}
		}

		public string? GeneratedPassword
		{
			get { return _password.GeneratedPassword; }
			private set 
			{
				_password.GeneratedPassword = value; 
				this.OnPropertyChanged(nameof(GeneratedPassword)); 
			}
		}

		public ICommand GeneratePasswordCommand { get; }

		public void GeneratePassword()
		{
			_password.GeneratePassword();
			this.OnPropertyChanged(nameof(GeneratedPassword));
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
		}
	}
}
