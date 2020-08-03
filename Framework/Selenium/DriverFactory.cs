using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        private static IWebDriver _driver;
        public static IWebDriver Build(string browserName)
        {
            FW.Log.Info($"Browser {browserName}");
            switch (browserName)
            {
                case "chrome":
                    var chromedriverlog_path = Path.GetFullPath(FW.WORKSPACE_DIRECTORY + "chromedriver.log");
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--verbose");
                    options.AddArgument($"--log-path={chromedriverlog_path}");

                    options.SetLoggingPreference(LogType.Browser, LogLevel.All);

                    var chrome_path = Path.GetFullPath(FW.WORKSPACE_DIRECTORY + "_drivers");
                    _driver = new ChromeDriver(chrome_path, options);

                    _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromMilliseconds(45000);
                    _driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromMilliseconds(400000);
                    _driver.Manage().Timeouts().AsynchronousJavaScript = System.TimeSpan.FromMilliseconds(90000);
                    ICapabilities capabilitiesChrome = ((RemoteWebDriver)_driver).Capabilities;
                    FW.Log.Info($"Capbilities: \n{capabilitiesChrome.ToString()}");
                    return _driver;
                    
                case "firefox":
                    _driver= new FirefoxDriver();
                    ICapabilities capabilities = ((RemoteWebDriver)_driver).Capabilities;
                    FW.Log.Info($"Capbilities: \n{capabilities.ToString()}");
                    return _driver;
                default:
                    throw new System.ArgumentException($"{browserName} not supported");
            }
            
        }
    }
}
