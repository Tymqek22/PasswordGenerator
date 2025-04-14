using PasswordGenerator.Enums;
using PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services.Interfaces
{
	public interface IPasswordValidatorService
	{
		List<PasswordValidationResult> Validate(string password);
		int CalculateStrengthScore(string password);
		string CalculateStrength(int score);
		bool HasProperLength(string password);
		bool HasUppercase(string password);
		bool HasLowercase(string password);
		bool HasDigits(string password);
		bool HasSpecialChars(string password);
		bool IsCommonPassword(string password);
		bool IsKeyboardPattern(string password);
		bool HasTooManyOccurences(string password);
		bool HasConsecutiveDuplicates(string password);
	}
}
