using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpressionParser.Test
{
    [TestClass]
    public class TestPositive
    {
        private RegExp _exp;
        public TestPositive()
        {
            _exp = new RegExp("1+2+");
        }

        [TestMethod]
        public void TestPositive_Match0()
        {
            bool result = _exp.IsMatch("1112222");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPositive_UnMatch11()
        {
            Assert.IsFalse(_exp.IsMatch("111"));
        }

        [TestMethod]
        public void TestPositive_UnMatch22()
        {
            Assert.IsFalse(_exp.IsMatch("222"));
        }

        [TestMethod]
        public void TestPositive_UnMatch()
        {
            bool result = _exp.IsMatch("33");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestPositive_UnMatch1()
        {
            Assert.IsFalse(_exp.IsMatch("11133"));
        }

        [TestMethod]
        public void TestPositive_UnMatch2()
        {
            Assert.IsFalse(_exp.IsMatch("11122233"));
        }
    }
}
