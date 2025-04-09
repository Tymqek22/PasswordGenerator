using PasswordGenerator.Enums;
using PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services.Interfaces
{
	public interface IPasswordGeneratorService
	{
		string GenerateInitialPassword(Password passwordModel);
		string GenerateValidPassword(Password rules);
		void Fix(ref string password, List<PasswordValidationResult> results, Password rules);
		string ReplaceMostCommonOccurences(string password,Password rules);

	}
}
