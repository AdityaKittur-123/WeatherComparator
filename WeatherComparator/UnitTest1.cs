using System;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using WeatherComparator.Utilities;
using LanguageExt.UnitsOfMeasure;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Assert = NUnit.Framework.Assert;
using System.Threading;
using WeatherComparator.PageObjectModel;
using System.Runtime.InteropServices;

namespace WeatherComparator
{

    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver= null;
        [TestMethod]
        public void WeatherComparator()
        {
            try
            {
                //webpage to fetch temperature
                Dictionary<string, string> prop = Utility.readProperties();

                Temperature tempUI = new Temperature();
                tempUI.setCity(prop["CityName"]);

                UIFunctions uifunc = new UIFunctions(driver);
                uifunc.Launch(prop);
                uifunc.navigateToWeatherPage();
                uifunc.explicitWait();
                uifunc.searchCity(prop);
                float uiTemp = uifunc.readCityWeatherDetails(prop);
                tempUI.setTemp(uiTemp);
                uifunc.closeDriver();

                //REST API to fetch temperature
                Temperature tempAPI = new Temperature();
                tempAPI.setCity(prop["CityName"]);
                //Create Client URL connection
                RestAPIFunctions apifunc = new RestAPIFunctions();
                apifunc.passClient(prop);
                //Create REST API Request
                apifunc.createRequest(prop);
                //Fetch response

                float apiTemp = apifunc.fetchResponse(prop);
                tempAPI.setTemp(apiTemp);

                Utility utilCompare = new Utility();
                Dictionary<string, string> prop2 = Utility.variance();
                utilCompare.Comparator(tempAPI.getTemp(), tempUI.getTemp(), prop2);
             
            }
            catch (Exception ex)
            {
              
            }
        }


    }
}

