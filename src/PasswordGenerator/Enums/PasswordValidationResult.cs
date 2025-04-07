using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Enums
{
	public enum PasswordValidationResult
	{
		Success,
		WrongLength,
		CommonPassword,
		KeyboardPattern,
		ConsecutiveDuplicates,
		TooManyOccurences
	}
}
