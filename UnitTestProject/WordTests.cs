using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	/// <summary>
	/// Сводное описание для WordTests
	/// </summary>
	[TestClass]
	public class WordTests
	{
		[TestMethod]
		public void TestDistance()
		{
			var w1 = new Word("муха");
			var w2 = new Word("слон");
			var w3 = new Word("муза");
			var w4 = new Word("клоп");
			Assert.IsTrue(w1.DistanceTo(w1) == 0);
			Assert.IsTrue(w1.DistanceTo(w2) == 4);
			Assert.IsTrue(w1.DistanceTo(w3) == 1);
			Assert.IsTrue(w2.DistanceTo(w4) == 2);
		}

		[TestMethod]
		public void TestIsOnlyOneLetterDiffWith()
		{
			var w1 = new Word("муха");
			var w2 = new Word("слон");
			var w3 = new Word("муза");
			var w4 = new Word("клоп");
			Assert.IsFalse(w1.IsOnlyOneLetterDiffWith(w1));
			Assert.IsFalse(w1.IsOnlyOneLetterDiffWith(w2));
			Assert.IsTrue(w1.IsOnlyOneLetterDiffWith(w3));
			Assert.IsFalse(w2.IsOnlyOneLetterDiffWith(w4));
		}

		[TestMethod]
		public void TestEquality()
		{
			var w1 = new Word("муха");
			var w2 = new Word("слон");
			var w3 = new Word("муха");
			Assert.IsTrue(w1 != w2);
			Assert.IsTrue(w1 == w3);
		}
	}
}
