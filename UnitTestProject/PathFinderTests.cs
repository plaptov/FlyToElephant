using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
	[TestClass]
	public class PathFinderTests
	{
		[TestMethod]
		public void TestPathFind()
		{
			IReader reader = new MockReader();
			var graph = WordsGraph.Generate(reader.ReadDictionary(null), 4);
			var path = PathFinder.FindShortestPath(graph, new Word("МУХА"), new Word("СЛОН"));
			Assert.IsNotNull(path);
		}
	}
}
