using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WeatherComparator.Utilities
{
  public  class RestAPIFunctions
    {

        private ExcelHelper Excelhelper
        {
            get { return new ExcelHelper("WeatherComparator"); }

        }

      public  RestClient client;
      public RestRequest request;



        public void passClient(Dictionary<string, string> prop)
        {
              string methodname = "GetWeatherMap";
        LogManager.InitiateLog(methodname);
                LogManager.WriteLog("--- API Testing started ----");
            //    client = new RestClient("https://api.openweathermap.org/data/2.5/");
            client = new RestClient(prop["APIUrl"]);

        LogManager.WriteLog("Client Passed");

            }


        public void createRequest(Dictionary<string, string> prop)
        {
            string  typeOfRequest = prop["Method"];
            foreach (string typeOfRequest1 in Enum.GetNames(typeof(Method)))
            {

              
                if (typeOfRequest == typeOfRequest1)
                {
                    if (typeOfRequest == "GET")
                    {
                        request = new RestRequest("weather", Method.GET);
                        LogManager.WriteLog("Request Created");

                        request.AddQueryParameter("q", prop["CityName"]);
                        request.AddQueryParameter("appid", prop["appid"]);
                    }
                    else if (typeOfRequest == "POST")
                    {
                        request = new RestRequest("weather", Method.POST);

                        //Any other Code for POST request
                    }
                    else if (typeOfRequest == "PATCH")
                    {
                        request = new RestRequest("weather", Method.PATCH);
                        //Any other Code for PATCH request
                    }
                    else if (typeOfRequest == "PUT")
                    {
                        request = new RestRequest("weather", Method.PUT);
                        //Any other Code for PUT request
                    }
                    else if (typeOfRequest == "DELETE")
                    {
                        request = new RestRequest("weather", Method.DELETE);
                        //Any other Code for DELETE request
                    }
                    else if (typeOfRequest == "HEAD")
                    {
                        request = new RestRequest("weather", Method.HEAD);
                        //Any other Code for HEAD request
                    }
                    else if (typeOfRequest == "MERGE")
                    {
                        request = new RestRequest("weather", Method.MERGE);
                        //Any other Code for MERGE request
                    }
                    else if (typeOfRequest == "COPY")
                    {
                        request = new RestRequest("weather", Method.COPY);
                        //Any other Code for COPY request
                    }
                    else if (typeOfRequest == "OPTIONS")
                    {
                        request = new RestRequest("weather", Method.OPTIONS);
                        //Any other Code for OPTIONS request
                    }
                }
            }
                   

        }


        public float fetchResponse(Dictionary<string, string> prop)
        {
            var response = client.Execute(request);
            //var p = JSON.stringify(response);
            //JSON.parse(p);
            
            //var string1 = (response.Content);
            //var main1 = string1.


            JObject obj = JObject.Parse(response.Content);
            JObject main = (JObject)obj["main"];
            string temp = main["temp"].ToString();

            LogManager.WriteLog("Response validation: Temperature in Kelvin: " + temp);
            JObject obj2 = JObject.Parse(response.Content);
            string CityName = obj["name"].ToString();
            LogManager.WriteLog("Response validation: City is: " + CityName);

            temp = temp.Remove(temp.Length() - 1, 1);

            float tempInKelvin = float.Parse(temp);
            float tempInDegrees = (float)(tempInKelvin - 273.15);
            Console.WriteLine("Temperature from REST API = " + tempInDegrees + " degrees celcius.");
            LogManager.WriteLog("Response Recorded: temp in degrees celcius is: " + tempInDegrees);
            Excelhelper.WriteToExcelLog(prop["CityName"], tempInDegrees);

            return tempInDegrees;
        }


    }
}
