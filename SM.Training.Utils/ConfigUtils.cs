using SoftMart.Core.Dao;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SM.Training.Utils
{
    public class ConfigUtils
    {
        private static Configuration ConfigurationManager { get; set; }

        /// <summary>
        /// Load file cấu hình
        /// </summary>
        /// <param name="folderPath">Folder chứa file cấu hình</param>
        public static void Load(string folderPath)
        {
            string filePath = Path.Combine(folderPath, "Configuration.xml");
            LogManager.System.LogDebug("Đọc file cấu hình bắt đầu: " + filePath);
            ConfigurationManager = SoftMart.Core.Utilities.SerializeHelper.DeserializeXmlFile<Configuration>(filePath);
            LogManager.System.LogDebug("Đọc file cấu hình thành công");
        }

        public static SqlPagingMode PagingMode
        {
            get
            {
                return SqlPagingMode.Offset;
            }
        }

        private static string _ApplicationDataConnection = null;
        public static string ApplicationDataConnection
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ApplicationDataConnection))
                {
                    _ApplicationDataConnection = ConfigurationManager.ConnectionStrings
                                                 .FirstOrDefault(c => c.Name == "ApplicationDatabase")
                                                 .ConnectionString;
                }

                return _ApplicationDataConnection;
            }
        }

        public static System.Data.IsolationLevel TransactionLevel
        {
            get
            {
                return System.Data.IsolationLevel.ReadCommitted;
            }
        }


        #region Configuration
        [XmlRoot("configuration")]
        public class Configuration
        {
            [XmlArray("connectionStrings")]
            [XmlArrayItem("add")]
            public List<ConnectionStringInfo> ConnectionStrings { get; set; }

            [XmlArray("appSettings")]
            [XmlArrayItem("add")]
            public List<AppSettingInfo> AppSettings { get; set; }

            #region Classes
            public class ConnectionStringInfo
            {
                [XmlAttribute("name")]
                public string Name { get; set; }

                [XmlAttribute("connectionString")]
                public string ConnectionString { get; set; }

                [XmlAttribute("providerName")]
                public string ProviderName { get; set; }

                [XmlAttribute("domain")]
                public string Domain { get; set; }
            }

            public class AppSettingInfo
            {
                [XmlAttribute("key")]
                public string Key { get; set; }

                [XmlAttribute("value")]
                public string Value { get; set; }
            }
            #endregion
        }
        #endregion
    }
}
