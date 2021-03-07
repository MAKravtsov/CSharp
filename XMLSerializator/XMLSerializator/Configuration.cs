using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSerializator
{
    public static class Configuration
    {
        private static Settings _settings;

        private static string _baseDirectory;

        public static Settings Settings
        {
            get
            {
                if (_settings == null)
                {
                    if (string.IsNullOrEmpty(_baseDirectory))
                        _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    _settings = Serializator.LoadXml<Settings>(@"C:\GitHub\MyLocalProjects\XMLSerializator\XMLSerializator\Settings.xml");
                }


                return _settings;
            }
            set
            {
                if (value == null)
                    return;

                _settings = value;

                if (string.IsNullOrEmpty(_baseDirectory))
                    _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                Serializator.SaveXml<Settings>(_settings, _baseDirectory + "\\Settings.xml");
            }
        }
    }
}
