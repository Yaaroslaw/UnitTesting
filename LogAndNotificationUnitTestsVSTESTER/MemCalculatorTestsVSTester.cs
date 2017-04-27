using LogAndNotification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogAndNotificationUnitTestsVSTESTER
{
    [TestClass]
    public class MemCalculatorTestsVSTester
    {
        private MemCalculator MakeCalculator() // Fabrical method 
        {
            return new MemCalculator();
        }

        [TestMethod]
        [TestCategory("SumTests")]
        public void Sum_ByDefault_ReturnsZero()
        {
            //Arrange
            var calculator = MakeCalculator();

            //Act
            int result = calculator.Sum();

            //Assert

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        [TestCategory("SumTests")]
        public void Add_WhenCalled_ChangesSumField()
        {
            //Arrange
            var calculator = MakeCalculator();

            //Act
            calculator.Add(11);
            int result = calculator.Sum();

            //Assert

            Assert.AreEqual(result, 11);
        }
    }
}
