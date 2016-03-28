using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyToElephant;

namespace UnitTestProject
{
	class MockReader : IReader
	{
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

		public string[] ReadStartAndFinish(string path)
		{
			return new[] { "МУХА", "СЛОН" };
		}
	}
}
