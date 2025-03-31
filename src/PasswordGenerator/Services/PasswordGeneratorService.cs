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
		public string GeneratePassword(int length,bool includeUppercase,bool includeLowercase,
			bool includeDigits,bool includeSpecial)
		{
			StringBuilder generatedPassword = new();
			Random rand = new();

			string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string lowercase = "abcdefghijklmnopqrstuvwxyz";
			string special = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}";
			string digits = "0123456789";

			StringBuilder charactersBase = new();

			if (includeUppercase) {
				charactersBase.Append(uppercase);
			}
			if (includeLowercase) {
				charactersBase.Append(lowercase);
			}
			if (includeDigits) {
				charactersBase.Append(digits);
			}
			if (includeSpecial) {
				charactersBase.Append(special);
			}

			for (int i = 0; i < length; i++) {

				generatedPassword.Append(charactersBase[rand.Next(charactersBase.Length)]);
			}

			return generatedPassword.ToString();
		}
	}
}
