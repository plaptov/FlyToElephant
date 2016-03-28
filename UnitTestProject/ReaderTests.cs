using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyToElephant;

namespace UnitTestProject
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void TestReader()
        {
			const string fakePath = null;
			IReader reader = new MockReader();
			var dict = reader.ReadDictionary(fakePath);
			Assert.IsNotNull(dict);
			Assert.IsTrue(dict.Length > 0);
			var sf = reader.ReadStartAndFinish(fakePath);
			Assert.IsNotNull(sf);
			Assert.IsTrue(sf.Length > 0);
        }
    }
}
