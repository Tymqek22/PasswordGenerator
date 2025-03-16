using System.Text;

namespace Domain
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

			for (int i = 0; i < 5; i++) {

				if (this.UseUppercase) {
					charactersBase.Append(uppercase[rand.Next(uppercase.Length)]);
				}
				if (this.UseLowercase) {
					charactersBase.Append(lowercase[rand.Next(lowercase.Length)]);
				}
				if (this.UseDigits) {
					charactersBase.Append(digits[rand.Next(digits.Length)]);
				}
				if (this.UseSpecialCharacters) {
					charactersBase.Append(special[rand.Next(special.Length)]);
				}
			}

			for (int i = 0; i < this.Length; i++) {

				generatedPassword.Append(charactersBase[rand.Next(charactersBase.Length)]);
			}

			this.GeneratedPassword = generatedPassword.ToString();
		}
	}

}
