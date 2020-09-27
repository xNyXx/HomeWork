using System;
using Calc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum_2plus3_5Returned()
        {
            Assert.AreEqual(Calculator.Calculate(2,"+",3),5);
        }
        
        [TestMethod]
        public void Sub_4minus3_1Returned()
        {
            Assert.AreEqual(Calculator.Calculate(4,"-",3),1);
        }
        [TestMethod]
        public void Dev_5devision5_1Returned()
        {
            Assert.AreEqual(Calculator.Calculate( 5,"/",5),1);
        }
        [TestMethod]
        public void Mult_5mult5_25Returned()
        {
            Assert.AreEqual(Calculator.Calculate( 5,"*",5),25);
        }
        [TestMethod]
        public void WrongOperation_InvalidOperation_ExceptionReturned()
        {
            Assert.ThrowsException<ArgumentException>(() => Calculator.Calculate(5, "nope", 5),"Invalid operation");
        }
        [TestMethod]
        public void Sum_0Devision_ExceptionReturned()
        {
            Assert.ThrowsException<Exception>(() => Calculator.Calculate(5, "/", 0),"Zero devision");
        }
    }
}