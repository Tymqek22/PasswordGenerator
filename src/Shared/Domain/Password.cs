
namespace Domain
{
	public class Password
	{
		public int Length { get; set; }
		public bool UseUpperCase { get; set; }
		public bool UseLowerCase { get; set; }
		public bool UseDigits { get; set; }
		public bool UseSpecialCharacters { get; set; }
		public string GeneratedPassword { get; set; }
	}

}
