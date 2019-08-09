using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_Framework.Helper
{
    public sealed class LogHelper
    {
        public LogHelper()
        {
        }

        static LogHelper instance = null;

        static readonly object padlock = new object();
        public static LogHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new LogHelper();
                        }
                    }
                }
                return instance;
            }
        }

        public void WriteLog(string documentName, string msg)
        {
            string errorLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(errorLogFilePath))
            {
                Directory.CreateDirectory(errorLogFilePath);
            }
            string logFile = Path.Combine(errorLogFilePath, documentName + "@" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt");
            bool writeBaseInfo = File.Exists(logFile);
            StreamWriter swLogFile = new StreamWriter(logFile, true, Encoding.Unicode);
            swLogFile.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t" + msg);
            swLogFile.Close();
            swLogFile.Dispose();
        }

    }
}
