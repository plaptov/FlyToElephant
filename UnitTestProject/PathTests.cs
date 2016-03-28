using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	[TestClass]
	public class PathTests
	{
		[TestMethod]
		public void TestPathInitAndCompare()
		{
			Word w1 = new Word("МУХА");
			Word w2 = new Word("МУКА");
			Word w3 = new Word("КЛОН");
			Word finish = new Word("СЛОН");

			Path p1 = new Path(null, w1, finish);
			Assert.AreEqual(p1.Length, 1);
			Assert.AreEqual(p1.Last, w1);

			Path p2 = new Path(p1, w2, finish);
			Assert.AreEqual(p2.Length, 2);
			Assert.AreEqual(p2.Last, w2);
			Assert.IsTrue(p1.Priority < p2.Priority);

			Path p3 = new Path(p1, w3, finish);
			Assert.AreEqual(p3.Length, 2);
			Assert.AreEqual(p3.Last, w3);
			Assert.IsTrue(p3.Priority < p2.Priority);
		}
	}
}
