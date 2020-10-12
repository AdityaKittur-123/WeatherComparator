using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherComparator.PageObjectModel;

namespace WeatherComparator.Utilities
{
    class UIFunctions
    {
        public IWebDriver driver;
        public UIFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ExcelHelper Excelhelper
        {
            get { return new ExcelHelper("WeatherComparator"); }

        }
        

        public  void Launch(Dictionary<string, string> prop)
        {

            string methodname = "GetWebAppTemp";
            LogManager.InitiateLog(methodname);
            LogManager.WriteLog("--- Web page Testing started ----");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = prop["Url"];
        }

        public void navigateToWeatherPage()
        {
            NDTVWeatherApp n = new NDTVWeatherApp(driver);
            n.showExtendedMenu();
            n.openWeatherPage();
           
        }

        public void explicitWait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("map_canvas")));
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public void searchCity(Dictionary<string, string> prop)
        {

            if (!(prop["CityName"] == "Mumbai" | prop["CityName"] == "Srinagar" | prop["CityName"] == "New Delhi" | prop["CityName"] == "Lucknow" |
               prop["CityName"] == "Patna" | prop["CityName"] == "Kolkata" | prop["CityName"] == "Visakhapatnam" | prop["CityName"] == "Hyderabad"
               | prop["CityName"] == "Bengaluru" | prop["CityName"] == "Chennai"))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("searchBox")));
             //   NDTVWeatherApp.searchCity(prop);
            
                NDTVWeatherApp.selectCity();
            

            }
        }


            public float readCityWeatherDetails(Dictionary<string, string> prop)
        {
            string tempInDegrees = NDTVWeatherApp.getTemperature();
          //  IWebElement selectTempDegrees = driver.FindElement(By.XPath("//div[contains(text(),'" + prop["CityName"] + "')]/../div/span[1]"));
         //   string tempInDegrees = selectTempDegrees.Text;

            tempInDegrees = tempInDegrees.Remove(tempInDegrees.Length()- 1,1);
            Console.WriteLine("Temperature from Webpage = "+tempInDegrees+" degrees celcius.");

            float temp = float.Parse(tempInDegrees);
            LogManager.WriteLog("Response validation: Temperature in Degrees: " + temp);
            LogManager.WriteLog("Response validation: City Name: " + prop["CityName"]);

            Excelhelper.WriteToExcelLog(prop["CityName"], temp);

            return temp;
        }

        public void closeDriver()
        {
            driver.Close();
        }



        }
}
