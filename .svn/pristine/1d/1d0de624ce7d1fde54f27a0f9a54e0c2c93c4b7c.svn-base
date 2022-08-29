using log4net;
using log4net.Repository;
using SoftMart.Core.Utilities.Diagnostics;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace SM.Training.Utils
{
    public class Log4Net : ILogger
    {
        #region Register logging config file
        private static readonly string _repositoryName;

        static Log4Net()
        {
            ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());
            _repositoryName = repository.Name;

            // Biến quy định folder log nằm trong folder ứng dụng. Ko quy định thì winservice sẽ trỏ vào system32
            string appDir = Utility.GetAssemblyFolder();
            log4net.GlobalContext.Properties["APP_DIR"] = appDir;
            log4net.GlobalContext.Properties["APP_SERVER"] = Environment.MachineName;

            string loggingFile = Path.Combine(appDir, "Logging.config");

            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo(loggingFile));
        }

        #endregion

        private ILog _logger = null;

        public ILogger GetLogger(string loggerName)
        {
            var instance = new Log4Net();
            try
            {
                instance._logger = log4net.LogManager.GetLogger(_repositoryName, loggerName);
            }
            catch { }
            return instance;
        }

        /// <summary>
        /// Log in Debug mode by default
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message, Exception ex = null)
        {
            if (_logger == null)
                return;

            if (_logger.IsDebugEnabled)
            {
                if (ex == null)
                    _logger.Debug(message);
                else
                    _logger.Debug(message, ex);
            }
        }

        /// <summary>
        /// Log in error mode by default
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message, Exception ex = null)
        {
            if (_logger == null)
                return;

            if (_logger.IsErrorEnabled)
            {
                if (ex == null)
                    _logger.Error(message);
                else
                    _logger.Error(message, ex);
            }
        }

        public void LogError(Exception ex)
        {
            LogError(string.Empty, ex);
        }
    }
}
