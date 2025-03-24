using System.Text;

namespace PasswordGenerator.Models
{
	public class Password
	{
		public int Length { get; set; }
		public bool UseUppercase { get; set; }
		public bool UseLowercase { get; set; }
		public bool UseDigits { get; set; }
		public bool UseSpecialCharacters { get; set; }
		public string? GeneratedPassword { get; set; }

		public void GeneratePassword()
		{
			StringBuilder generatedPassword = new();
			Random rand = new();

			string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string lowercase = "abcdefghijklmnopqrstuvwxyz";
			string special = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}";
			string digits = "0123456789";

			StringBuilder charactersBase = new();

			if (this.UseUppercase) {
				charactersBase.Append(uppercase);
			}
			if (this.UseLowercase) {
				charactersBase.Append(lowercase);
			}
			if (this.UseDigits) {
				charactersBase.Append(digits);
			}
			if (this.UseSpecialCharacters) {
				charactersBase.Append(special);
			}

			for (int i = 0; i < this.Length; i++) {

				generatedPassword.Append(charactersBase[rand.Next(charactersBase.Length)]);
			}

			this.GeneratedPassword = generatedPassword.ToString();
		}

		public bool HasTooManyDuplicatedChars(string password)
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

		public bool HasDuplicatedNeighbourChars(string password)
		{
			char earlierChar = password[0];

			for (int i = 1; i < password.Length; i++) {

				if (earlierChar == password[i]) {

					return true;
				}
			}

			return false;
		}
	}

}
