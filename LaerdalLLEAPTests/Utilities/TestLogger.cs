using System;
using System.IO;

namespace LaerdalLLEAPTests.Utilities
{
    public static class TestLogger
    {
        private static string logDirectory = @"C:\Users\Public\Documents\LLEAP Test Logs";
        
        public static void Log(string testName, string message)
        {
            Directory.CreateDirectory(logDirectory);
            string logPath = Path.Combine(logDirectory, $"{testName}_Results.txt");
            File.AppendAllText(logPath, $"{DateTime.Now}: {message}\n");
        }
        
        public static void ClearLog(string testName)
        {
            Directory.CreateDirectory(logDirectory);
            string logPath = Path.Combine(logDirectory, $"{testName}_Results.txt");
            File.WriteAllText(logPath, "");
        }
    }
}