using System.IO;
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
	}

}
