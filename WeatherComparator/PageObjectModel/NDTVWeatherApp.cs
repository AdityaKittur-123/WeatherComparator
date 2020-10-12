using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherComparator.Utilities;

namespace WeatherComparator.PageObjectModel
{
    public class NDTVWeatherApp
    {
        public static IWebDriver webDriver;

      //  public static Dictionary<string, string> prop = new Dictionary<string, string>();
        public static Dictionary<string, string> prop = Utility.readProperties();
        public NDTVWeatherApp(IWebDriver driver)
        {
            NDTVWeatherApp.webDriver = driver;
        }


        #region Properties

        private static By byextendedMenu_Xpath
        {
            get
            {
                return By.XPath("//a[@id='h_sub_menu']");
            }
        }

        private static By byweather_Xpath
        {
            get
            {
                return By.XPath("//a[contains(text(),'WEATHER')]");
            }
        }

        private static By bysearchCity_Xpath
        {
            get
            {
                return By.XPath("//input[@id='searchBox']");
            }
        }

        private static By byselectCity_Xpath
        {
            get
            {
                return By.CssSelector("#" + prop["CityName"]);
            }
        }

        private static By byselectTempDegrees_Xpath
        {
            get
            {
                return By.XPath("//div[contains(text(),'" + prop["CityName"] + "')]/../div/span[1]");
            }
        }
        #endregion Properties


        #region IWebElement
        private static IWebElement extendedMenu_Xpath
        {
            get
            {
                return webDriver.FindElement(byextendedMenu_Xpath);
            }
        }

        private static IWebElement weather_Xpath
        {
            get
            {
                return webDriver.FindElement(byweather_Xpath);
            }
        }

        private static IWebElement searchCity_Xpath
        {
            get
            {
                return webDriver.FindElement(bysearchCity_Xpath);
            }
        }

        private static IWebElement selectCity_Xpath
        {
            get
            {
                return webDriver.FindElement(byselectCity_Xpath);
            }
        }
        private static IWebElement selectTempDegrees_Xpath
        {
            get
            {
                return webDriver.FindElement(byselectTempDegrees_Xpath);
            }
        }
        #endregion IWebElement

        #region Methods
        public  void showExtendedMenu()
        {
            extendedMenu_Xpath.Click();

        }

        public  void openWeatherPage()
        {
            weather_Xpath.Click();

        }


        public static void searchCity(Dictionary<string, string> prop)
        {

            searchCity_Xpath.SendKeys(prop["CityName"]);

        }


        public static void selectCity()
        {
               
            selectCity_Xpath.Click();
         
        }


        public static string getTemperature()
        {
            string tempInDegrees = selectTempDegrees_Xpath.Text;
            return tempInDegrees;
        }

        
        #endregion Methods

    }
}
