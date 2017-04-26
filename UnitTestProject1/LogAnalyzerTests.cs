using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogAndNotification;

namespace LogAndNotificationUnitTests
{
    [TestClass]
    public class LogAnalyzerTests
    {
        /// <summary>
        /// Code convention: [UnitOfWorkName]_[ScenarioUnderTest]_[ExpectedBehavior].
        /// </summary>
        [TestMethod]
        public void IsLogFileNameValid_BadExtension_ReturnsFalse()
        {
            // Arrange
            LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");
            //Assert
            Assert.IsFalse(result);
        }
    }
}

