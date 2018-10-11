using MA01ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertTest
{
    [TestClass]
    public class MyConvertTest
    {
        [TestMethod]
        public void ConvertToGramsPositiveTest()
        {
            Assert.AreEqual(MyConvert.ToGrams(2), 2 * MyConvert.RATIO, 0.1);
        }

        [TestMethod]
        public void ConvertToGramsNegativeTest()
        {
            Assert.AreEqual(MyConvert.ToGrams(-4), -4 * MyConvert.RATIO, 0.1);
        }

        [TestMethod]
        public void ConvertToGramsZeroTest()
        {
            Assert.AreEqual(MyConvert.ToGrams(0),0,0.1);
        }

        [TestMethod]
        public void ConvertoOuncesPosiveTest()
        {
            Assert.AreEqual(MyConvert.ToOunces(2), 2 / MyConvert.RATIO,0.1);
        }

        [TestMethod]
        public void ConvertoOuncesNegativeTest()
        {
            Assert.AreEqual(MyConvert.ToOunces(-2), -2 / MyConvert.RATIO, 0.1);
        }

        [TestMethod]
        public void ConvertToOuncesZeroTest()
        {
            Assert.AreEqual(MyConvert.ToGrams(0), 0, 0.1);
        }
    }
}
