using PasswordGenerator.Enums;
using PasswordGenerator.Models;
using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services
{
	public class PasswordGeneratorService : IPasswordGeneratorService
	{
		private readonly IPasswordValidatorService _validatorService;

		public PasswordGeneratorService(IPasswordValidatorService validatorService)
		{
			_validatorService = validatorService;
		}

		private string BulidCharatersBase(Password rules)
		{
			StringBuilder charactersBase = new();

			string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string lowercase = "abcdefghijklmnopqrstuvwxyz";
			string special = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}";
			string digits = "0123456789";

			if (rules.UseUppercase)
				charactersBase.Append(uppercase);

			if (rules.UseLowercase)
				charactersBase.Append(lowercase);

			if (rules.UseDigits)
				charactersBase.Append(digits);

			if (rules.UseSpecialCharacters)
				charactersBase.Append(special);

			return charactersBase.ToString();
		}

		public string GenerateInitialPassword(Password passwordModel)
		{
			StringBuilder generatedPassword = new();
			Random rand = new();

			string charactersBase = this.BulidCharatersBase(passwordModel);

			for (int i = 0; i < passwordModel.Length; i++) {

				generatedPassword.Append(charactersBase[rand.Next(charactersBase.Length)]);
			}

			return generatedPassword.ToString();
		}

		public string GenerateValidPassword(Password rules)
		{
			string password = this.GenerateInitialPassword(rules);
			var issues = _validatorService.Validate(password,rules);

			while (issues.Any(iss => iss != PasswordValidationResult.Success)) {

				this.Fix(ref password,issues,rules);
				issues = _validatorService.Validate(password,rules);
			}

			return password;
		}

		public void Fix(ref string password, List<PasswordValidationResult> results, Password rules)
		{
			foreach (var result in results) {

				switch (result) {
					case PasswordValidationResult.WrongLength:
					case PasswordValidationResult.CommonPassword:
					case PasswordValidationResult.KeyboardPattern:
						password = this.GenerateInitialPassword(rules);
						break;
					case PasswordValidationResult.ConsecutiveDuplicates:
						password = this.ReplaceConsecutiveCharacters(password);
						break;
					case PasswordValidationResult.TooManyOccurences:
						password = this.ReplaceMostCommonOccurences(password,rules);
						break;
				}
			}
		}

		public string ReplaceMostCommonOccurences(string password, Password rules)
		{
			var passwordList = password.ToList();
			Random rand = new();

			var mostCommonChar = passwordList
				.GroupBy(c => c)
				.OrderByDescending(grp => grp.Count())
				.First()
				.Key;

			var occurences = passwordList.Count(c => c == mostCommonChar);
			int charsToReplace = occurences / 2;
			int charsReplaced = 0;

			string charactersBase = this.BulidCharatersBase(rules);

			for (int i = 0; (i < password.Length) && (charsReplaced < charsToReplace); i++) {

				if (passwordList[i] == mostCommonChar) {

					passwordList[i] = charactersBase[rand.Next(charactersBase.Length)];
					charsReplaced++;
				}
			}

			return passwordList.ToString();
		}

		public string ReplaceConsecutiveCharacters(string password)
		{
			Random rand = new();

			char[] passwordChars = password.ToCharArray();

			for (int i = 0; i < passwordChars.Length - 1; i++) {

				if (passwordChars[i] == passwordChars[i+1]) {

					char newChar;

					do {
						newChar = (char)rand.Next(33,127);

					} while (newChar == passwordChars[i]);

					passwordChars[i + 1] = newChar;
				}
			}

			return new string(passwordChars);
		}
	}
}
