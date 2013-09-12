using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Common
{
    public class Utils
    {
        public class AppSettings
        {
            public static string GetValue(string key)
            {
                if (KeyExists(key))
                    return ConfigurationManager.AppSettings[key];
                return string.Empty;
            }
            private static bool KeyExists(string key)
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]);
            }
            private static bool KeyExists(int index)
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings[index]);
            }
        }
    }
}
