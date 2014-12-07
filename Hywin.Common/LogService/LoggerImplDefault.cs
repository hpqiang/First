using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Hywin.Common.LogService
{
    internal class LoggerImplDefault<T> : ILogger<T>
    {
        private static String _fullClassName = String.Empty;

        protected static String FullClassName
        {
            get
            {
                if (_fullClassName == String.Empty)
                {
                    _fullClassName = typeof(T).ToString();
                }
                return _fullClassName;
            }
        }

        protected static TraceSwitch s_ts = new TraceSwitch(FullClassName, "");
        protected static LogLevel _logLevel = LogLevel.UNKNOWN;

        #region ILogger Members

        public LogLevel LogLevel
        {
            get
            {
                if (_logLevel == LogLevel.UNKNOWN)
                {

                }
                return _logLevel;
            }
        }

        protected void WriteLogMsg(LogLevel logLevelSetting, LogLevel logLevelTarget, String originalMsg)
        {
            if (logLevelSetting > logLevelTarget) return;

            //String msg = FullClassName + "." + (new StackTrace()).GetFrame(2).GetMethod().Name + ": " + Enum.GetName(typeof(LogLevel), logLevelTarget) + ": " + originalMsg;
            String msg = string.Format("{0}.{1}: {3}: {4}", FullClassName,
                                       (new StackTrace()).GetFrame(2).GetMethod().Name,
                                       Enum.GetName(typeof(LogLevel), logLevelTarget), originalMsg);
            switch (logLevelTarget)
            {
                case LogLevel.DEBUG:
                    Trace.WriteLineIf(s_ts.TraceVerbose, msg);
                    break;
                case LogLevel.INFO:
                    Trace.WriteLineIf(s_ts.TraceInfo, msg);
                    break;
                case LogLevel.WARN:
                    Trace.WriteLineIf(s_ts.TraceWarning, msg);
                    break;
                case LogLevel.ERROR:
                    Trace.WriteLineIf(s_ts.TraceError, msg);
                    break;
                case LogLevel.FATAL:
                    Trace.WriteLineIf(s_ts.TraceError, msg);
                    break;
                default:
                    break;
            }
        }

        public void Debug(string msg)
        {
            WriteLogMsg(LogLevel, LogLevel.DEBUG, msg);
        }

        public void Info(string msg)
        {
            WriteLogMsg(LogLevel, LogLevel.INFO, msg);
        }

        public void Warn(string msg)
        {
            WriteLogMsg(LogLevel, LogLevel.WARN, msg);
        }

        public void Warn(Exception ex)
        {
            WriteLogMsg(LogLevel, LogLevel.WARN, ex.Message);
        }

        public void Warn(string msg, Exception ex)
        {
            WriteLogMsg(LogLevel, LogLevel.WARN, msg + " " + ex.Message);
        }

        public void Error(string msg)
        {
            WriteLogMsg(LogLevel, LogLevel.ERROR, msg);
        }

        public void Error(Exception ex)
        {
            WriteLogMsg(LogLevel, LogLevel.ERROR, ex.Message);
        }

        public void Error(string msg, Exception ex)
        {
            WriteLogMsg(LogLevel, LogLevel.ERROR, msg + " " + ex.Message);
        }

        public void Fatal(string msg)
        {
            WriteLogMsg(LogLevel, LogLevel.FATAL, msg);
        }

        public void Fatal(Exception ex)
        {
            WriteLogMsg(LogLevel, LogLevel.FATAL, ex.Message);
        }

        public void Fatal(string msg, Exception ex)
        {
            WriteLogMsg(LogLevel, LogLevel.FATAL, msg + " " + ex.Message);
        }

        #endregion


    }
}