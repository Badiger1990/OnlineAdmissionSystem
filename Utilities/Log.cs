using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAdmissionSystem.Utilities
{
    public class Log
    {
        private static readonly Log _instance=new Log();
        protected ILog monitoringLogger;
        protected ILog debugLogger;

        public Log()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        public static void Debug(string message)
        {
            _instance.debugLogger.Debug(message);
        }

        public static void Info(string message)
        {
            _instance.monitoringLogger.Info(message);
        }

        public static void Error(string message)
        {
            _instance.monitoringLogger.Error(message);
        }

        public static void Warn(string message)
        {
            _instance.monitoringLogger.Warn(message);
        }
    }
}