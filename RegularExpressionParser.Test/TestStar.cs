using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpressionParser.Test
{
    [TestClass]
    public class TestStar
    {
        private RegExp _exp;
        public TestStar()
        {
            _exp = new RegExp("1*2*");
        }

        [TestMethod]
        public void TestStar_Match0()
        {
            bool result = _exp.IsMatch("1112222");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestStar_Match1()
        {
            Assert.IsTrue(_exp.IsMatch("111"));
        }

        [TestMethod]
        public void TestStar_Match2()
        {
            Assert.IsTrue(_exp.IsMatch("222"));
        }

        [TestMethod]
        public void TestStar_UnMatch()
        {
            bool result = _exp.IsMatch("33");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestStar_UnMatch1()
        {
            Assert.IsFalse(_exp.IsMatch("11133"));
        }

        [TestMethod]
        public void TestStar_UnMatch2()
        {
            Assert.IsFalse(_exp.IsMatch("11122233"));
        }
    }
}
