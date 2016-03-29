using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyToElephant
{
	/// <summary>
	/// Интерфейс читателя файлов. Выделен для возможности создания объекта-заглушки
	/// </summary>
	public interface IReader
	{
		/// <summary>
		/// Считать словарь из файла
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <returns>Список слов</returns>
		string[] ReadDictionary(string path);
		/// <summary>
		/// Считать из файла начальное и конечное слова
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <returns>Список из первого и конечного слов</returns>
		string[] ReadStartAndFinish(string path);
	}
	/// <summary>
	/// Читатель файлов. Считывает данные из файла в кодировке UTF-8
	/// </summary>
	public class Reader : IReader
	{
		/// <summary>
		/// Считать словарь из файла
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <returns>Список слов</returns>
		public string[] ReadDictionary(string path)
		{
			return File.ReadAllLines(path);
		}
		/// <summary>
		/// Считать из файла начальное и конечное слова
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <returns>Список из первого и конечного слов</returns>
		public string[] ReadStartAndFinish(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}
