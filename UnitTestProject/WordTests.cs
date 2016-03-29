using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	/// <summary>
	/// Тесты класса слова
	/// </summary>
	[TestClass]
	public class WordTests
	{
		/// <summary>
		/// Тест вычисления расстояния между словами
		/// </summary>
		[TestMethod]
		public void TestDistance()
		{
			// Создаём тестовые слова
			var w1 = new Word("муха");
			var w2 = new Word("слон");
			var w3 = new Word("муза");
			var w4 = new Word("клоп");
			// Слово должно быть равно само себе
			Assert.IsTrue(w1.DistanceTo(w1) == 0);
			// Если все буквы разные, расстояние должно быть 4
			Assert.IsTrue(w1.DistanceTo(w2) == 4);
			// Отличие в одну букву
			Assert.IsTrue(w1.DistanceTo(w3) == 1);
			// Отличие в две буквы
			Assert.IsTrue(w2.DistanceTo(w4) == 2);
		}
		/// <summary>
		/// Тест проверки на отличие только одной буквы
		/// </summary>
		[TestMethod]
		public void TestIsOnlyOneLetterDiffWith()
		{
			// Тестовые слова
			var w1 = new Word("муха");
			var w2 = new Word("слон");
			var w3 = new Word("муза");
			var w4 = new Word("клоп");
			// Не должно выдаватся true для самого себя, т.к. слова равны
			Assert.IsFalse(w1.IsOnlyOneLetterDiffWith(w1));
			// Не должно выдаватся true для полностью разных слов
			Assert.IsFalse(w1.IsOnlyOneLetterDiffWith(w2));
			// При отличии в одну букву должно выдаваться true
			Assert.IsTrue(w1.IsOnlyOneLetterDiffWith(w3));
			// При отличии в две буквы не должно выдаваться true
			Assert.IsFalse(w2.IsOnlyOneLetterDiffWith(w4));
		}
		/// <summary>
		/// Тест сравнения слов на равенство
		/// </summary>
		[TestMethod]
		public void TestEquality()
		{
			var w1 = new Word("муха");
			var w2 = new Word("слон");
			var w3 = new Word("муха");
			// муха не равна слону
			Assert.IsTrue(w1 != w2);
			// две разных мухи равны
			Assert.IsTrue(w1 == w3);
		}
	}
}
