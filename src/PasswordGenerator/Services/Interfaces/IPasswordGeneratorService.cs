using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services.Interfaces
{
	public interface IPasswordGeneratorService
	{
		string GeneratePassword(int length,bool includeUppercase,bool includeLowercase,bool includeDigits,
			bool includeSpecial);
	}
}
