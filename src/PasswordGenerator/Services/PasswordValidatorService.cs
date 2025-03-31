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
		public bool HasProperLength(string password) => password.Length >= 8 && password.Length <= 50;

		public async Task<bool> IsCommonPassword(string password)
		{
			List<string> commonPasswords = new();

			string path = Path.Combine(Environment.CurrentDirectory,"\\Files\\Common_Passwords.txt");
			
			if (File.Exists(path)) {

				commonPasswords = await Task.Run(() => File.ReadAllLines(path).ToList());
			}

			foreach (var commonPass in commonPasswords) {

				if (commonPass == password) return true;
			}

			return false;
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

		public bool HasRepeatedSequence(string password,int sequenceLength)
		{
			throw new NotImplementedException();
		}

		public bool HasTooManyOccurences(string password)
		{
			var passwordList = password.ToList();

			var duplicatesCount = passwordList
				.GroupBy(c => c)
				.Select(grp => grp.Count())
				.ToList();

			if (password.Length >= 8 && password.Length <= 16) {

				return duplicatesCount.Any(c => c >= 3);
			}
			else if (password.Length > 16 && password.Length <= 20) {

				return duplicatesCount.Any(c => c >= 4);
			}
			else if (password.Length > 20 && password.Length <= 30) {

				return duplicatesCount.Any(c => c >= 5);
			}
			else if (password.Length > 30 && password.Length <= 40) {

				return duplicatesCount.Any(c => c >= 6);
			}
			else if (password.Length > 40 && password.Length <= 50) {

				return duplicatesCount.Any(c => c >= 7);
			}

			return true;
		}

		public bool IsKeyboardPattern(string password)
		{
			throw new NotImplementedException();
		}
	}
}
