using System;
using System.IO;

namespace Framework.Logging
{
    public class Logger
    {
        private readonly string _filePath;
        private readonly string dateFormat= "yyyy/MM/dd HH:mm:ss.fffff";
        public Logger(string testName, string filePath)
        {
            _filePath = filePath;

            using (var log = File.CreateText(_filePath))
            {
                log.WriteLine($"Starting timestamp: {DateTime.Now.ToLocalTime().ToString(dateFormat)}");
                log.WriteLine($"Test: {testName}");
            }
        }

        private void WriteLine(string text)
        {
            using var log = File.AppendText(_filePath);
            log.WriteLine(text);
        }

        private void Write(string text)
        {
            using var log = File.AppendText(_filePath);
            log.Write(text);
        }

        public void Info(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime().ToString(dateFormat)} [INFO]: {message}");
        }
        public void Step(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime().ToString(dateFormat)} [STEP]:     {message}");
        }
        public void Warning(string message)
        {
            WriteLine($"{ DateTime.Now.ToLocalTime().ToString(dateFormat)}[WARNING]: {message}");
        }
        public void Error(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime().ToString(dateFormat)} [ERROR]: {message}");
        }
        public void Fatal(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime().ToString(dateFormat)} [FATAL]: {message}");
        }
    }
}
