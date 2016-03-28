using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	[TestClass]
	public class WordsGraphTests
	{
		[TestMethod]
		public void TestGraphGenerating()
		{
			const int wordLen = 4;
			IReader reader = new MockReader();
			var dict = reader.ReadDictionary(null);
			var graph = WordsGraph.Generate(dict, wordLen);
			Assert.IsNotNull(graph);
			Assert.AreNotEqual(graph.Count, 0);
			Assert.IsTrue(graph.All(kv => kv.Key.Text.Length == wordLen));
			Assert.IsTrue(graph.Any(kv => kv.Value != null && kv.Value.Length > 0));
			Assert.IsTrue(graph.All(kv =>
				kv.Value != null &&
				(kv.Value.Length > 0 ||
				 Array.TrueForAll(kv.Value, w =>
					kv.Key.DistanceTo(w) == 1))));
		}
	}
}
