using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpressionParser.Test
{
    [TestClass]
    public class TestString
    {
        private RegExp _exp;
        public TestString()
        {
            _exp = new RegExp("(ab)*c");
        }

        [TestMethod]
        public void TestString_Match()
        {
            Assert.IsTrue(_exp.IsMatch("ababc"));
        }

        [TestMethod]
        public void TestString_NotMatch()
        {
            Assert.IsFalse(_exp.IsMatch("abac"));
        }
    }
}
