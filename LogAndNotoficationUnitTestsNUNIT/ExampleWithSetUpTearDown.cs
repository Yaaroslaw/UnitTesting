using LogAndNotification;
using NUnit.Framework;

namespace LogAndNotoficationUnitTestsNUNIT
{
    public class ExampleWithSetUpTearDown
    {
        private LogAnalyzer _analyzer = null;

        [SetUp]
        public void SetUp()
        {
            // Arrange 
            _analyzer = new LogAnalyzer();
        }
        [Test]
        public void IsLogFileNameValid_BadExtensions_ReturnsFalse()
        {    
            //Act
            var result = _analyzer.IsLogFileNameValid("invalidFileName.Foo");

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase("fileWithAGoodExtensionLowercase.slf")]
        [TestCase("fileWithAGoodExtentionUpperCase.SLF")]
        public void IsLogFileNameValid_GoodExtensions_ReturnsTrue(string fileName)
        {
            //Act
            var result = _analyzer.IsLogFileNameValid(fileName);

            //Assert
            Assert.IsTrue(result);
        }

        [TearDown]
        public void TearDown()
        {
            _analyzer = null; //Demonstration of anti-pattern, actually this line is not needed.
        }
    }
}
