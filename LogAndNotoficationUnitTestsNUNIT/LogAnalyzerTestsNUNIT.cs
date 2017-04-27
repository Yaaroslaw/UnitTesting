using LogAndNotification;
using NUnit.Framework;

namespace LogAndNotoficationUnitTestsNUNIT
{
    [TestFixture]
    public class LogAnalyzerTestsNUNIT
    {
        [Test]
        public void IsLogFileNameValid_BadExtension_ReturnsFalse()
        {
            // Arrange
            LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsLogFileNameValid_GoodExtensionLowerCase_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.IsLogFileNameValid("fileWithAGoodExtensionLowercase.slf");
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsLogFileNameValid_GoodExtensionUpperCase_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.IsLogFileNameValid("fileWithAGoodExtentionUpperCase.SLF");
            //Assert
            Assert.IsTrue(result);
        }
    }
}
