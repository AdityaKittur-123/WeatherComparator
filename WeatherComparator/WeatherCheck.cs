//using System;
//using LanguageExt;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Newtonsoft.Json;
//using NUnit.Framework;
//using Newtonsoft.Json.Linq;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using RestSharp;
//using WeatherComparator.Utilities;
//using LanguageExt.UnitsOfMeasure;
//using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Remoting.Contexts;
//using Assert = NUnit.Framework.Assert;
//using System.Threading;
//using WeatherComparator.Utility;
//using WeatherComparator.PageObjectModel;

//namespace WeatherComparator
//{



//    [TestClass]
//    public class WeatherCheck : NDTVWeatherApp
//    {
//        private ExcelHelper Excelhelper
//        {
//            get { return new ExcelHelper("WeatherComparator"); }

//        }

//        //string CityName;
//        //string temperature;

//        //public UnitTest1(string temperature, string CityName)
//        //{
//        //    this.temperature = temperature;
//        //    this.CityName = CityName;
//        //}

//        RestClient client;
//        RestRequest request;

//        //[DeploymentItem("MyTestProject\\data.xlsx")]
//        //[DataSource("MyExcelDataSource")]
//        [TestMethod]
//        public void ndtvWeather()
//        {
//            //    string CityName = Context.DataRow["CityName"].ToString();


//            //var data = new Dictionary<string, string>();
//            ////CHANGE FILE PATH
//            //foreach (var row in File.ReadAllLines(@"C:\Users\kittua\Desktop\TestVagrantAssignment\WeatherComparator\WeatherComparator\Utilities\test.properties"))
//            //    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

//            //Console.WriteLine(data["CityName"]);
//            string CityName = data["CityName"];
//            string methodname = "GetWebAppTemp";
//            LogManager.InitiateLog(methodname);
//            LogManager.WriteLog("--- Web page Testing started ----");
        
//           NDTVWeatherApp.webDriver.Manage().Window.Maximize();
//           NDTVWeatherApp.webDriver.Url = "https://www.ndtv.com/";

//            //Add implicit wait---
//            //Use Assert 

//             NDTVWeatherApp.extendedMenu();
//            NDTVWeatherApp.weather();
//            NDTVWeatherApp.searchCity();
//            NDTVWeatherApp.selectCity();
//            NDTVWeatherApp.selectTempDegrees();
            
//            IWebElement weather = driver.FindElement(By.XPath("//a[contains(text(),'WEATHER')]"));
//            weather.Click();

//            Thread.Sleep(5000);
//            IWebElement searchCity = driver.FindElement(By.XPath("//input[@id='searchBox']"));

//            searchCity.SendKeys(data["CityName"]);

//            IWebElement selectCity = driver.FindElement(By.CssSelector("#" + CityName));
//            selectCity.Click();

//            IWebElement selectTempDegrees = driver.FindElement(By.XPath("//div[contains(text(),'" + data["CityName"] + "')]/../div/span[1]"));
//            string tempInDegrees = selectTempDegrees.Text;
          
//            Console.WriteLine(tempInDegrees);
//            LogManager.WriteLog("Response validation: Temperature in Degrees: " + tempInDegrees);
//            LogManager.WriteLog("Response validation: City Name: " + data["CityName"]);

//            Excelhelper.WriteToExcelLog(data["CityName"], tempInDegrees);

//            NDTVWeatherApp.webDriver.Close();

//        }



//        [TestMethod]
//        public void GetWeatherMap()
//        {
//            try
//            {
//                var data = new Dictionary<string, string>();
//                //CHANGE FILE PATH
//                foreach (var row in File.ReadAllLines(@"C:\Users\kittua\Desktop\TestVagrantAssignment\WeatherComparator\WeatherComparator\Utilities\test.properties"))
//                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

//                Console.WriteLine(data["CityName"]);


//                string methodname = "GetWeatherMap";
//                LogManager.InitiateLog(methodname);
//                LogManager.WriteLog("--- API Testing started ----");
//                client = new RestClient("https://api.openweathermap.org/data/2.5/");
//                LogManager.WriteLog("Client Passed");

//                request = new RestRequest("weather", Method.GET);
//                LogManager.WriteLog("Request Created");
//                //   request.AddQueryParameter("q", "Bengaluru");
//                request.AddQueryParameter("q", data["CityName"]);
//                request.AddQueryParameter("appid", "7fe67bf08c80ded756e598d6f8fedaea");

//                LogManager.WriteLog("Parameters passed!");
//                var response = client.Execute(request);
//                JObject obj = JObject.Parse(response.Content);
//                JObject main = (JObject)obj["main"];
//                string temp = main["temp"].ToString();


//                LogManager.WriteLog("Response validation: Temperature in Kelvin: " + temp);

//                JObject obj2 = JObject.Parse(response.Content);
//                string CityName = obj["name"].ToString();
//                LogManager.WriteLog("Response validation: City is: " + CityName);
//                //  int tempKelvin = Int32.Parse(temp);
//                //         int a = Int32.Parse(temp.ToString());
//                //int tempKelvin = Convert.ToInt32(temp);

//                //      int tempKelvin = int.Parse(temp);
//                //int tempCelcius = (int)(tempKelvin - 273.15);
//                //  int tempCelcius = (int)(tempKelvin - 273.15);
//                //     LogManager.WriteLog("Response validation: Temperature in Celcuis: " + tempCelcius);
//                LogManager.WriteLog("Response Recorded");
//                Excelhelper.WriteToExcelLog(data["CityName"], temp);
//                //     CityTemperature ct1 = new CityTemperature(temp, name);

//                //      return temp;
//            }
//            catch (Exception ex)
//            {
//                LogManager.WriteLog("Test Case failed because:" + ex.Message);
//                //     return null;
//            }

//        }

//        // UnitTest1 ct1 = new UnitTest1(temperature, CityName);

//        //public void comparator(UnitTest1 ct1, UnitTest1 ct2)
//        //{

//        //    //UnitTest1 actual = new UnitTest1 { temperature = 1, CityName =  };
//        //    //UnitTest1 expected = new UnitTest1 { temperature = 1, CityName =  };

//        //   // Assert.Equal(expected, actual);
//        //    Assert.AreEqual(ct1, ct2, "Yes equal");
//        //}


//    }
//}
