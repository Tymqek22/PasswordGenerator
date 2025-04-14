using PasswordGenerator.Enums;
using PasswordGenerator.Models;
using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services
{
	public class PasswordValidatorService : IPasswordValidatorService
	{
		private readonly IFileReader _fileReaderService;

		public PasswordValidatorService(IFileReader fileReader)
		{
			_fileReaderService = fileReader;
		}

		public List<PasswordValidationResult> Validate(string password)
		{
			var validationResults = new List<PasswordValidationResult>();

			if (this.HasProperLength(password))
				validationResults.Add(PasswordValidationResult.Success);
			else
				validationResults.Add(PasswordValidationResult.WrongLength);

			if (this.IsCommonPassword(password))
				validationResults.Add(PasswordValidationResult.CommonPassword);
			else
				validationResults.Add(PasswordValidationResult.Success);

			if (this.IsKeyboardPattern(password))
				validationResults.Add(PasswordValidationResult.KeyboardPattern);
			else
				validationResults.Add(PasswordValidationResult.Success);

			if (this.HasTooManyOccurences(password))
				validationResults.Add(PasswordValidationResult.TooManyOccurences);
			else
				validationResults.Add(PasswordValidationResult.Success);

			if (this.HasConsecutiveDuplicates(password))
				validationResults.Add(PasswordValidationResult.ConsecutiveDuplicates);
			else
				validationResults.Add(PasswordValidationResult.Success);

			return validationResults;
		}

		public int CalculateStrengthScore(string password)
		{
			int score = 0;

			if (string.IsNullOrWhiteSpace(password))
				return 0;

			if (this.HasProperLength(password)) score+=30;
			if (password.Length >= 15) score += 10;
			if (this.HasUppercase(password)) score+=10;
			if (this.HasLowercase(password)) score+=10;
			if (this.HasDigits(password)) score+=10;
			if (this.HasSpecialChars(password)) score+=10;
			if (!this.HasTooManyOccurences(password)) score+=10;
			if (!this.HasConsecutiveDuplicates(password)) score+=10;
			if (this.IsCommonPassword(password) || this.IsKeyboardPattern(password)) score = 0;

			return score;
		}

		public string CalculateStrength(int score)
		{
			return score switch
			{
				<= 40 => "Weak",
				50 => "Medium",
				60 => "Medium",
				70 => "Medium",
				80 => "Medium",
				> 80 => "Strong"
			};
		}

		public bool HasProperLength(string password) => password.Length >= 8 && password.Length <= 50;

		public bool HasUppercase(string password) => password.Any(c => c >= 65 && c <= 90);

		public bool HasLowercase(string password) => password.Any(c => c >= 97 && c <= 122);

		public bool HasDigits(string password) => password.Any(c => c >= 48 && c <= 57);

		public bool HasSpecialChars(string password) => password.Any(c => !char.IsLetterOrDigit(c));

		public bool IsCommonPassword(string password)
		{
			List<string> commonPasswords = _fileReaderService
												.GetAllFileLines(@"Files\Common_Passwords.txt")
												.ToList();

			return commonPasswords.Any(pass => pass == password);
		}

		public bool HasConsecutiveDuplicates(string password)
		{
			char earlierChar = password[0];

			for (int i = 1; i < password.Length; i++) {

				if (earlierChar == password[i]) {

					return true;
				}
				earlierChar = password[i];
			}

			return false;
		}

		public bool HasTooManyOccurences(string password)
		{
			var passwordList = password.ToList();

			var duplicatesCount = passwordList
				.GroupBy(c => c)
				.Select(grp => grp.Count())
				.ToList();

			int maxDuplicates = (int)(password.Length * 0.2);

			maxDuplicates = Math.Min(maxDuplicates,7);

			return duplicatesCount.Any(c => c > maxDuplicates);
		}

		public bool IsKeyboardPattern(string password)
		{
			List<string> keyboardPatterns = _fileReaderService
												.GetAllFileLines(@"Files\Keyboard_Pattern_Passwords.txt")
												.ToList();

			return keyboardPatterns.Any(pass => pass == password);
		}
	}
}
