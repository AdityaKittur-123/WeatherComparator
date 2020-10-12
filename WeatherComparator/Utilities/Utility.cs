using NUnit.Framework;
using System;   
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Joins;
using System.Text;
using System.Threading.Tasks;

namespace WeatherComparator.Utilities
{
  public   class Utility
    {
        public static Dictionary<string, string> readProperties(){
            var data = new Dictionary<string, string>();

                foreach (var row in File.ReadAllLines(@"WeatherComparator\Utilities\test.properties"))
                data.Add(row.Split('=')[0], string.Join(" = ", row.Split('=').Skip(1).ToArray()));

            return data;
            }

        public static Dictionary<string, string> variance()
        {
            var data = new Dictionary<string, string>();
          
            foreach (var row in File.ReadAllLines(@"WeatherComparator\Utilities\variance.properties"))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

            return data;
        }


        public void Comparator(float t1, float t2, Dictionary<string, string> prop2)
        {
            float TempWebApp = t1;
            float TempAPI = t2;
            string varianceString = prop2["variance"];
            float variance = float.Parse(varianceString);
            try
            {
                if (!(  TempWebApp== TempAPI))
                {
                    float difference = (TempWebApp - TempAPI);
                    float absDifference = Math.Abs(difference);
                    if (absDifference < variance)
                        Console.WriteLine("Success, temperature's from both Web Page and API Matches.");
                    else
                    {
                        Assert.That((absDifference < variance), Is.True, "The temperatures do not match. Their difference is beyond the variance allowed");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Test Case failed because: " + ex.Message);
                LogManager.WriteLog("Test Case failed because: " + ex.Message);
            }

        }

    }

      
}

