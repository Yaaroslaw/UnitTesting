using LogAndNotification;
using NUnit.Framework;
using System;

namespace LogAndNotoficationUnitTestsNUNIT
{
    [TestFixture]
    public class LogAnalyzerTestsNUNIT
    {
        private LogAnalyzer MakeAnalyzer() // Fabrical method 
        {
            return new LogAnalyzer();
        }

        [Test]
        [Category("NiceTests")]
        public void IsLogFileNameValid_BadExtensions_ReturnsFalse()
        {
            // Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase("fileWithAGoodExtensionLowercase.slf")]
        [TestCase("fileWithAGoodExtentionUpperCase.SLF")]
        [Category("NiceTests")]
        public void IsLogFileNameValid_GoodExtensions_ReturnsTrue(string fileName)
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            //Act
            var result = analyzer.IsLogFileNameValid(fileName);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        [Category("NiceTests")]
        public void IsLogFileNameValid_EmptyString_ReturnsException()
        {
            //Arrange
            LogAnalyzer analyzer = MakeAnalyzer();

            // Act and Assert
            var ex = Assert.Catch<Exception>(() => analyzer.IsLogFileNameValid("")); // if code inside
                                                                                     //lamda-fucntion generates and exception
                                                                                     //test passes, if not or exception is thrown
                                                                                     // by other parts of the code - doesn't.
            StringAssert.Contains("File has to have a name!", ex.Message);
        }


        [Test]
        [Ignore("This test is not implemented yet")]
        [Category("IgnoredTests")]
        public void notWorkingTest()
        {
            throw new NotImplementedException();
        }
    }
}
