using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using LNDL.Hywin.Common.LogService;

namespace Hywin.Common.LogService
{
    public static class Log<T>
    {
        private static ILogger<T> _logger;

        public static ILogger<T> LogProvider
        {
            get
            {
                if (_logger == null) _logger = new LoggerImplDefault<T>();
                return _logger;
            }
            set { _logger = value; }
        }

        public static LogLevel LogLevel
        {
            get
            {
                return LogProvider.LogLevel;
            }
        }

        public static void Debug(String msg)
        {
            LogProvider.Debug(msg);
        }
        public static void Info(String msg)
        {
            LogProvider.Info(msg);
        }
        public static void Warn(String msg)
        {
            LogProvider.Warn(msg);
        }
        public static void Warn(Exception ex)
        {
            LogProvider.Warn(ex);
        }
        public static void Warn(String msg, Exception ex)
        {
            LogProvider.Warn(msg,ex);
        }
        public static void Error(String msg)
        {
            LogProvider.Error(msg);
        }
        public static void Error(Exception ex)
        {
            LogProvider.Error(ex);
        }
        public static void Error(String msg, Exception ex)
        {
            LogProvider.Error(msg, ex);
        }
        public static void Fatal(String msg)
        {
            LogProvider.Fatal(msg);
        }
        public static void Fatal(Exception ex)
        {
            LogProvider.Fatal(ex);
        }
        public static void Fatal(String msg, Exception ex)
        {
            LogProvider.Fatal(msg, ex);
        }

    }
}