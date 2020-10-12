using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using WeatherComparator.Utilities;
namespace WeatherComparator.Step_Defination_files
{
    [Binding]
    public class WeatherApiTestSteps
    {
        
       
        [Given(@"a valid API with key value pair to be passed")]
        public void GivenAValidAPIWithKeyValuePairToBePassed()
        {
            //Get Input
            Dictionary<string, string> prop = Utility.readProperties();
            //Create Client URL connection
            RestAPIFunctions apifunc = new RestAPIFunctions();
            apifunc.passClient(prop);
        }

        [When(@"request to the API is sent")]
        public void WhenRequestToTheAPIIsSent(RestAPIFunctions apifunc,Dictionary<string, string> prop)
        {
            apifunc.createRequest(prop);
        }

        [Then(@"the response from the API gets us the Temperature of the Indian City")]
        public void ThenTheResponseFromTheAPIGetsUsTheTemperatureOfTheIndianCity(RestAPIFunctions apifunc,Dictionary<string, string> prop)
        {
            apifunc.fetchResponse(prop);
        }
    }
}
