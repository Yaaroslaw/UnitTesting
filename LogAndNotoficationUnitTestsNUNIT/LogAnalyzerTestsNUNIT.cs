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

        [TestCase("fileWithAGoodExtensionLowercase.slf")]
        [TestCase("fileWithAGoodExtentionUpperCase.SLF")]
        public void IsLogFileNameValid_GoodExtensions_ReturnsTrue(string fileName)
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();
            //Act
            var result = analyzer.IsLogFileNameValid(fileName);
            //Assert
            Assert.IsTrue(result);
        }
    }
}
