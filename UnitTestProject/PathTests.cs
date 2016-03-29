using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	/// <summary>
	/// Тесты класса пути в графе
	/// </summary>
	[TestClass]
	public class PathTests
	{
		/// <summary>
		/// Тест инициализации и сравнения путей
		/// </summary>
		[TestMethod]
		public void TestPathInitAndCompare()
		{
			// Тестовые слова
			Word w1 = new Word("МУХА");
			Word w2 = new Word("МУКА");
			Word w3 = new Word("КЛОН");
			Word finish = new Word("СЛОН");
			// Создаём новый путь из одного слова
			// Проверяем передачу null в качестве исходного
			Path p1 = new Path(null, w1, finish);
			// Длина графа должна быть 1, т.к. слово одно
			Assert.AreEqual(p1.Length, 1);
			// Последнее слово должно быть только что добавленное
			Assert.AreEqual(p1.Last, w1);
			// Создаём второй путь на основе первого
			Path p2 = new Path(p1, w2, finish);
			// Длина должна быть 2
			Assert.AreEqual(p2.Length, 2);
			// Последнее слово должно быть только что добавленное
			Assert.AreEqual(p2.Last, w2);
			// Приоритет первого пути должен быть ниже, т.к. длина у
			// него меньше, а расстояние до финиша одинаковое
			// Абсолютные величины нас тут не интересуют
			Assert.IsTrue(p1.Priority < p2.Priority);
			// Создаём третий путь на основе тоже первого
			Path p3 = new Path(p1, w3, finish);
			// Длина должна быть 2
			Assert.AreEqual(p3.Length, 2);
			// Последнее слово должно быть только что добавленное
			Assert.AreEqual(p3.Last, w3);
			// Приоритет третьего пути должен быть ниже, чем у второго,
			// т.к. КЛОН ближе к СЛОН, че МУКА
			Assert.IsTrue(p3.Priority < p2.Priority);
		}
	}
}
