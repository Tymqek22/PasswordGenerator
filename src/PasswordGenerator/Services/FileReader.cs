using PasswordGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services
{
	public class FileReader : IFileReader
	{
		public IEnumerable<string> GetAllFileLines(string path)
		{
			var lines = new List<string>();

			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectRoot = Path.GetFullPath(Path.Combine(basePath,@"..\..\..\..\"));
			string finalPath = Path.Combine(projectRoot,path);

			if (File.Exists(finalPath)) {

				lines = File.ReadAllLines(finalPath).ToList();
			}

			return lines;
		}
	}
}
