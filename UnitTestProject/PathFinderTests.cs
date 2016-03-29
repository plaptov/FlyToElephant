using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	/// <summary>
	/// Тесты для класса поиска пути по графу
	/// </summary>
	[TestClass]
	public class PathFinderTests
	{
		/// <summary>
		/// Тест поиска пути
		/// </summary>
		[TestMethod]
		public void TestPathFind()
		{
			// Создаём ридер-заглушку
			IReader reader = new StubReader();
			// Генерируем граф
			var graph = WordsGraph.Generate(reader.ReadDictionary(null), 4);
			var sf = reader.ReadStartAndFinish(null);
			// Ищем решение в графе
			var path = PathFinder.FindShortestPath(graph, new Word(sf[0]), new Word(sf[1]));
			// Решение должно быть найдено
			Assert.IsNotNull(path);
		}
	}
}
