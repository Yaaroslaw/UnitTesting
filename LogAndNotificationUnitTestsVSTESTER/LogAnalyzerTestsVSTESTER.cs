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
        [TestMethod]
        public void IsLogFileNameValid_BadExtension_ReturnsFalse()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLogFileNameValid_GoodExtensionLowerCase_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("validFileName.slf");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLogFileNameValid_GoodExtensionUpperCase_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("validFileName.SLF");

            //Assert
            Assert.IsTrue(result);
        }
    }
}
