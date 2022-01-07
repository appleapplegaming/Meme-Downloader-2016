﻿namespace Dottik.Logging
{
    internal class Log : WriteLogs
    {
        /// <summary>
        /// Log information into the application's log file
        /// </summary>
        public static void LOGI(string textToLog)
        {
            string thingToLog = $"[{DateTime.Now}] : I PID:{Environment.ProcessId} - {textToLog}";

            WriteLogs wlogs = new();

            Thread informationThread = new(() => wlogs.WriteToFile(thingToLog, InternalProgramData.DataFolder + @"Logs\", "log.log"));
            informationThread.Start();
        }
        /// <summary>
        /// Log a warning into the application's log file
        /// </summary>
        public static void LOGW(string textToLog)
        {
            string thingToLog = $"[{DateTime.Now}] : W PID:{Environment.ProcessId} - {textToLog}";

            WriteLogs wlogs = new();

            new Thread (

                () => wlogs.WriteToFile(thingToLog, InternalProgramData.DataFolder + @"Logs\", "log.log")
                
                ).Start();
        }
        /// <summary>
        /// Log a error into the application's log file
        /// </summary>
        public static void LOGE(string textToLog)
        {
            string thingToLog = $"[{DateTime.Now}] : E PID:{Environment.ProcessId} - {textToLog}";

            WriteLogs wlogs = new();

            new Thread(

                () => wlogs.WriteToFile(thingToLog, InternalProgramData.DataFolder + @"Logs\", "log.log")

                ).Start();
        }
        /// <summary>
        /// Log debug data into the application's log file, ONLY ON DEBUG MODE!
        /// </summary>
        public static void LOGD(string textToLog)
        {
            #if DEBUG

            string thingToLog = $"[{DateTime.Now}] : D PID:{Environment.ProcessId} - {textToLog}";

            WriteLogs wlogs = new();

            new Thread(

                () => wlogs.WriteToFile(thingToLog, InternalProgramData.DataFolder + @"Logs\", "log.log")

                ).Start();

            #endif
        }
    }
    public class WriteLogs
    {
        private static object fileLocker = new();
        /// <summary>
        /// Write UTF-8 Text to a *.txt file
        /// </summary>
        public void WriteToFile(string data, string directory, string fileName)
        {
            lock (fileLocker)
            {
                string finalPath = Path.Combine(directory, fileName);

                //Create a directory, if exist it won't do anything
                Directory.CreateDirectory(directory);

                using StreamWriter sw = File.AppendText(finalPath);

                sw.WriteLine(data);
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
        }
    }
}
