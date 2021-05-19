using System;
using System.Collections.Generic;
using System.Text;
using OtpNet;
using System.IO;

namespace HOTPKeyGeneratorApp
{
    public static class BusinessLogic
    {
        private static byte[] _secret = null;
        private static byte[] Secret => _secret ??= GetSecret();
        private static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string AppDirectory => Path.Combine(AppData, "HOTPKeyGeneratorApp");
        private static string CounterFilePath => Path.Combine(AppDirectory, "counter.txt");

        public static void CreateDirectoryAndFileIfNotExist()
        {
            // The folder for the roaming current user
            Directory.CreateDirectory(AppDirectory);
            if (!File.Exists(CounterFilePath))
            {
                var file = File.Create(CounterFilePath);
                file.Close();
            }
        }

        private static int GetCounter()
        {
            var text = File.ReadAllText(CounterFilePath);
            if (string.IsNullOrEmpty(text))
                text = "0";
            return int.Parse(text);
        }

        private static void WriteCounter(int counter)
        {
            File.WriteAllText(CounterFilePath, counter.ToString());
        }

        private static byte[] GetSecret()
        {
            var secret = System.Configuration.ConfigurationManager.AppSettings["Secret"];
            return Base32Encoding.ToBytes(secret);
        }

        public static string GenerateKey()
        {
            var counter = GetCounter();
            var hotp = new Hotp(Secret);
            var key = hotp.ComputeHOTP(counter);
            WriteCounter(counter + 1);
            return key;
        }
    }
}
