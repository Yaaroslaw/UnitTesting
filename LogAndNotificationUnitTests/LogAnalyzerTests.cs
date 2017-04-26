using LogAndNotification;
using NUnit.Framework;


namespace LogAndNotificationUnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {/// <summary>
     /// Code convention: [UnitOfWorkName]_[ScenarioUnderTest]_[ExpectedBehavior].
     /// </summary>
        [Test]
        public void IsLogFileNameValid_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            var result = analyzer.IsLogFileNameValid("invalidFileName.Foo");
            Assert.False(result);
        }
    }
}
