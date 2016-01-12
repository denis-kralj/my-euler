using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Utility
{
    public enum WriteModeEnum
    {
        OnlyMemory,
        File,
        WindowsLog
    }

    public static class Crack
    {
        private static String _defaultLogFileName = "data.log";

        private static List<CrackLog> _logList = new List<CrackLog>();

        private static String _logPath;

        private static Stopwatch _timer = new Stopwatch();

        private static Boolean logToFile = false;

        private static WriteModeEnum writeMode = WriteModeEnum.OnlyMemory;

        public static string[] Log
        {
            get
            {
                return Crack._logList.Select(l => l.ToString()).ToArray();
            }
        }
        public static Boolean LogToFile
        {
            get { return logToFile; }
            set { logToFile = value; }
        }
        public static WriteModeEnum WriteMode
        {
            get { return writeMode; }
            set { writeMode = value; }
        }
        private static String _defaultLogDir
        {
            get
            {
                var dirName = "Crack";
                var myDocuments =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments
                        );

                return Path.Combine(myDocuments, dirName);
            }
        }

        public static void LogEvent(string message)
        {
            switch (Crack.WriteMode)
            {
                case WriteModeEnum.OnlyMemory:
                    Crack._logList.Add(new CrackLog(message));
                    break;
                case WriteModeEnum.File:
                    Crack._logList.Add(new CrackLog(message));
                    File.AppendAllLines(Crack._logPath, Crack.Log);
                    break;
                case WriteModeEnum.WindowsLog:
                    using (EventLog eventLog = new EventLog("Crack"))
                    {
                        eventLog.Source = "Crack";
                        eventLog.WriteEntry(message, EventLogEntryType.Information);
                    }
                    break;
                default:
                    break;
            }

        }

        public static void SetLogLocation(String path)
        {
            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                Crack._logPath = Path.Combine(path, Crack._defaultLogFileName);
            }
            else
            {
                if (File.Exists(path))
                    File.Delete(path);

                Crack._logPath = path;
            }
            File.Create(Crack._logPath).Dispose();
        }

        public static void Start()
        {
            _timer.Reset();
            _timer.Start();

            var message = "Started performance log in method Start()";
            Crack.LogEvent(message);
        }
        public static void Stop()
        {
            _timer.Stop();
            var message = "Stoped performance log in method Stop()";
            Crack.LogEvent(message);
            message = String.Format("Elpased time : {0}", _timer.Elapsed);
            Crack.LogEvent(message);
        }

        private struct CrackLog
        {
            private DateTime created;

            private String message;

            public CrackLog(String message) : this()
            {
                Created = DateTime.Now;
                Message = message;
            }
            public DateTime Created
            {
                get { return created; }
                private set { created = value; }
            }
            public String Message
            {
                get { return message; }
                set { message = value; }
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return String.Format("{0} => {1}", this.Created, this.Message);
            }
        }
    }
}