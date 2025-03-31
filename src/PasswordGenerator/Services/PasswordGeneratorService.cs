using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services
{
	public class PasswordGeneratorService : IPasswordGeneratorService
	{
		public string GeneratePassword(int length,bool includeUppercase,bool includeLowercase,
			bool includeDigits,bool includeSpecial)
		{
			throw new NotImplementedException();
		}
	}
}
