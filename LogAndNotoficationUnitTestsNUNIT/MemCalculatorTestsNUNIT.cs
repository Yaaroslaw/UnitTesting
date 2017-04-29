

using LogAndNotification;
using NUnit.Framework;

namespace LogAndNotoficationUnitTestsNUNIT
{
    [TestFixture]
    public class MemCalculatorTestsNunit
    {
        private MemCalculator MakeCalculator() // Fabrical method 
        {
            return new MemCalculator();
        }

        [Test]
        [Category("SumTests")]
        public void Sum_ByDefault_ReturnsZero()
        {
            //Arrange
            var calculator = MakeCalculator();

            //Act
            int result = calculator.Sum();

            //Assert

            Assert.AreEqual(result, 0);
        }

        [Test]
        [Category("SumTests")]
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
