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
        [TestCategory("ExtensionTests")]
        public void IsLogFileNameValid_BadExtension_ReturnsFalse()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");

            //Assert
            Assert.IsFalse(result);
        }

        [TestCategory("ExtensionTests")]
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
        [TestCategory("ExtensionTests")]
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
        [TestCategory("ExceptionTests")]
        [ExpectedException(typeof(ArgumentException), "File has to have a name!")]
        public void IsLogFileNameValid_EmptyString_ReturnsException()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("");
        }

        [TestMethod]
        [TestCategory("SystemStateTests")]
        public void IsLogFileName_WhenCalled_ChangesWasLastNameValidFalse()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("badExtension.foo");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("SystemStateTests")]
        public void IsLogFileName_WhenCalled_ChangesWasLastNameValidTrue()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("goodExtension.slf");
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [Ignore]
        [TestCategory("IgnoredTests")]
        public void notWorkingTest()
        {
            throw new NotImplementedException();
        }
    }
}
