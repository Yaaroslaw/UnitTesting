using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogAndNotification;

namespace LogAndNotificationUnitTestsVSTESTER
{
    [TestClass]
    public class LogAnalyzerTestsVSTESTER
    {
        /// <summary>
        /// Code convention: [UnitOfWorkName]_[ScenarioUnderTest]_[ExpectedBehavior].
        /// </summary>


        private LogAnalyzer MakeAnalyzer() // Fabrical method 
        {
            return new LogAnalyzer();
        }

        [TestMethod]
        public void IsLogFileNameValid_BadExtension_ReturnsFalse()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLogFileNameValid_GoodExtensionLowerCase_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("validFileName.slf");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLogFileNameValid_GoodExtensionUpperCase_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();
            try
            {
                //Act
                var result = analyzer.IsLogFileNameValid("sdadadas");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Bad way to it, as if there are other exceptions, the test will pass nonetheless.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "File has to have a name!")]
        public void IsLogFileNameValid_EmptyString_ReturnsException()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("");
        }
    }
}
