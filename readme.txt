Step 1: Clean and Build project

Step 2: Go to test.properties file to change the Value against the Key 'CityName'


Properties Files:
relative Location: WeatherComparator\WeatherComparator\bin\Debug\WeatherComparator\Utilities






------------------------------------------------------------------------------------------

1. test.properties :
NOTE: The 'Url'(i.e Webpage url) , 'APIUrl' and 'appid' in this file are already set as a part of one time setup. 

Note: The 'Method' key value to be set to the API request (i.e. GET,POST,PUT,etc)


2. variance.properties :
		If you want to change the allowed temperature variance between the temperatures fetched from both the Webpage and the REST API, then change the value for the Variance key.








------------------------------------------------------------------------------------------
Extra information:


Utilities:(NOTE: AUTO CREATED UTILITIES- NO USER INTERVENTION REQUEIRED)

1. Log Manager: Auto-creates two seperate text files in test reports folder:
relative path: WeatherComparator\WeatherComparator\TestReports.
Use: Utility for Debugging the code fragments.


2. Output file (excel): Auto-creates in the C drive within folder name same as name of the project.
Use: Utility for having a view at all the outputs at a glance.

3. One Test case also created in Specflow as an example.
