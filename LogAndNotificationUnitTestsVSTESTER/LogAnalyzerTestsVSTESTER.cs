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
            LogAnalyzer analyzer = new LogAnalyzer();
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLogFileNameValid_GoodExtensionLowerCase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            var result = analyzer.IsLogFileNameValid("validFileName.slf");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLogFileNameValid_GoodExtensionUpperCase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            var result = analyzer.IsLogFileNameValid("validFileName.SLF");
            Assert.IsTrue(result);
        }
    }
}
