using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	/// <summary>
	/// Интерфейс читателя файлов. Выделен для возможности создания mock-объекта
	/// </summary>
	public interface IReader
	{
		string[] ReadDictionary(string path);

		string[] ReadStartAndFinish(string path);
	}

	public class Reader : IReader
	{
		public string[] ReadDictionary(string path)
		{
			return File.ReadAllLines(path);
		}

		public string[] ReadStartAndFinish(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}
