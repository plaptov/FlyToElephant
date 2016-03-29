using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyToElephant;

namespace UnitTestProject
{
	/// <summary>
	/// Заглушка-реализация читателя для тестов.
	/// Реализован для слов из 4-ч букв.
	/// </summary>
	class StubReader : IReader
	{
		/// <summary>
		/// Считать словарь (путь не учитывается)
		/// </summary>
		public string[] ReadDictionary(string path)
		{
			return new[]
			{
				"МУХА",
				"МУКА",
				"РУКА",
				"РУНА",
				"ПУНА",
				"ПУЛА",
				"КУЛА",
				"КИЛА",
				"КИЛТ",
				"КИОТ",
				"КРОТ",
				"ШРОТ",
				"ШКОТ",
				"СКОТ",
				"СЛОТ",
				"СЛОН",
				"КОТ",
				"МОСЬКА",
				"ЖИРАФ",
				"И",
				"БРАК",
				"ХЛЕБ"
			};
		}
		/// <summary>
		/// Считать начальное и конечное слова (путь не учитывается)
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public string[] ReadStartAndFinish(string path)
		{
			return new[] { "МУХА", "СЛОН" };
		}
	}
}
