using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hywin.Common.LogService
{
    public enum LogLevel
    {
        ALL = 1,
        DEBUG = 2,
        INFO = 3,
        WARN = 4,
        ERROR = 5,
        FATAL = 6,
        OFF = 500,
        UNKNOWN = 1000
    };

    public interface ILogger<T>
    {
        LogLevel LogLevel { get; }

        void Debug(String msg);
        void Info(String msg);

        void Warn(String msg);
        void Warn(Exception ex);
        void Warn(String msg, Exception ex);

        void Error(String msg);
        void Error(Exception ex);
        void Error(String msg, Exception ex);

        void Fatal(String msg);
        void Fatal(Exception ex);
        void Fatal(String msg, Exception ex);

    }
}