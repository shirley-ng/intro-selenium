using System;
using System.Configuration;

namespace FrameworkExample
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private static ConfigurationProvider _current;

        string IConfigurationProvider.Uri
        {
            get { return ConfigurationManager.AppSettings["Uri"]; }
        }

        string IConfigurationProvider.Browser
        {
            get { return ConfigurationManager.AppSettings["Browser"]; }
        }
        
        TimeSpan IConfigurationProvider.Timeout
        {
            get { return TimeSpan.FromSeconds(TimeoutSeconds); }
        }

        private int TimeoutSeconds
        {
            get { return Int32.Parse(ConfigurationManager.AppSettings["Timeout"]); }
        }

        public static ConfigurationProvider Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new ConfigurationProvider();
                }
                return _current;
            }
        }

        private ConfigurationProvider()
        {
        }
    }
}