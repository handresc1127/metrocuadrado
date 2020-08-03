using NUnit.Framework;
using Framework;
using Framework.Selenium;
using NUnit.Framework.Interfaces;
using MetroCuadrado.Pages;

namespace MetroCuadrado.Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Page.Init();
            Driver.Goto(FW.Config.Test.Url);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            FW.Log.Info($"Outcome: {outcome.ToString()}");
            if (outcome != TestStatus.Passed)
            {
                Driver.TakeScreenshot("test_Failed", FW.CurrentTestDirectory.FullName);
            }
            Driver.Quit();
        }
    }
}
