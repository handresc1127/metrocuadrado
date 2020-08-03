using System;
using System.IO;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic] 
        private static IWebDriver _driver;
        [ThreadStatic] 
        public static Wait Wait;
        [ThreadStatic]
        public static Window Window;
        public static void Init()
        {
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
            Wait = new Wait(FW.Config.Driver.WaitSeconds);
            Window = new Window();
            Window.Maximize();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");
        public static string Title => Current.Title;

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static void TakeScreenshot(string imageName,string customPath)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(customPath,imageName);
            ss.SaveAsFile($"{ssFileName}.png",ScreenshotImageFormat.Png);
            FW.Log.Info($"Screenshot saved as {ssFileName}.png");
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
            Current.Dispose();
        }

        public static Element FindElement(By by, string elementName)
        {
            FW.Log.Info($"Find Element By {by}");
            var element = Wait.Until(drvr => drvr.FindElement(by));
            return new Element(element, elementName)
            {
                FoundBy=by
            };
        }

        public static Elements FindElements(By by)
        {
            FW.Log.Info($"Find Elements By {by}");
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }
    }
}
