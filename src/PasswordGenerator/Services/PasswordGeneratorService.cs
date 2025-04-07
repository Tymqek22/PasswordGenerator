using PasswordGenerator.Models;
using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services
{
	public class PasswordGeneratorService : IPasswordGeneratorService
	{
		public string GeneratePassword(Password passwordModel)
		{
			StringBuilder generatedPassword = new();
			Random rand = new();

			string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string lowercase = "abcdefghijklmnopqrstuvwxyz";
			string special = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}";
			string digits = "0123456789";

			StringBuilder charactersBase = new();

			if (passwordModel.UseUppercase) {
				charactersBase.Append(uppercase);
			}
			if (passwordModel.UseLowercase) {
				charactersBase.Append(lowercase);
			}
			if (passwordModel.UseDigits) {
				charactersBase.Append(digits);
			}
			if (passwordModel.UseSpecialCharacters) {
				charactersBase.Append(special);
			}

			for (int i = 0; i < passwordModel.Length; i++) {

				generatedPassword.Append(charactersBase[rand.Next(charactersBase.Length)]);
			}

			return generatedPassword.ToString();
		}
	}
}
