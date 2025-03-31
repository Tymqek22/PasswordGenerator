using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services.Interfaces
{
	public interface IPasswordValidatorService
	{
		bool HasProperLength(string password);
		bool IsCommonPassword(string password);
		bool HasRepeatedSequence(string password,int sequenceLength);
		bool IsKeyboardPattern(string password);
		bool HasTooManyOccurences(string password, int maxAllowed);
		bool HasConsecutiveDuplicates(string password);
	}
}
