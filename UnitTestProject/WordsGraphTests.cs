using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	/// <summary>
	/// Тесты графа слов
	/// </summary>
	[TestClass]
	public class WordsGraphTests
	{
		/// <summary>
		/// Тест генерации графа
		/// </summary>
		[TestMethod]
		public void TestGraphGenerating()
		{
			// Берём слова из 4 букв
			const int wordLen = 4;
			// Создаём ридер-заглушку и считываем словарь
			IReader reader = new StubReader();
			var dict = reader.ReadDictionary(null);
			// Генерируем граф
			var graph = WordsGraph.Generate(dict, wordLen);
			// Граф должен быть
			Assert.IsNotNull(graph);
			// Граф должен быть не пуст
			Assert.AreNotEqual(graph.Count, 0);
			// Все слова в графе должны быть заданной длины
			Assert.IsTrue(graph.All(kv => kv.Key.Text.Length == wordLen));
			// В графе должно быть хотя бы одно слово, у которого есть возможные переходы
			Assert.IsTrue(graph.Any(kv => kv.Value != null && kv.Value.Count > 0));
			// У всех слов в графе
			Assert.IsTrue(graph.All(kv =>
				// Список переходов должен быть не null
				kv.Value != null &&
				// И он либо пуст
				(kv.Value.Count > 0 ||
				// Либо все переходы отличаются только на одну букву
				 kv.Value.TrueForAll(w =>
					kv.Key.IsOnlyOneLetterDiffWith(w)))));
		}
	}
}
