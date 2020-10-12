using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherComparator.Utilities
{

    //LOG MANAGER CAPTURES STEP BY STEP LOGS FOR EASY DEBUGGING OF THE CODE
    class LogManager
    {

        public static string logFile;
        public static void WriteLog(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(logFile))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("---Test case failed because of the following reason, ---" + ex.Message);
                throw ex;
            }
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                //txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("[" + System.DateTime.Now.ToLongTimeString() + "]  :{0}", logMessage);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("---Test case failed because of the following reason, ---" + ex.Message);
                throw ex;
            }
        }

        public static void InitiateLog(string logMessage)
        {
            try
            {
                //CHANGE FILE PATH//
                logFile = @"C:\Users\kittua\Desktop\TestVagrantAssignment\Weather Comparator Modified\WeatherComparator\WeatherComparator\TestReports\"; //TO BE CHANGED TO LOCAL LOCATION APP.CONFIG COULD BE USED.
                logFile += logMessage + ".txt";
                //; // +"_" + region + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss")
                using (StreamWriter txtWriter = File.AppendText(logFile))
                {

                    txtWriter.WriteLine("{0}", logMessage);
                    txtWriter.WriteLine("{0}", "---------------------------------------------");
                    txtWriter.WriteLine("{0} {1} : ", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog("---Test case failed because of the following reason, ---" + ex.Message);
                throw ex;
            }
        }

        public static void CloseLog()
        {
            if (true)
            {
                Console.WriteLine("\n");
                var logLines = File.ReadAllLines(logFile);
                foreach (var line in logLines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("\n");
            }
        }




    }
}
