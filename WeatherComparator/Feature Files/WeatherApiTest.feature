Feature: WeatherApiTest
	API

@mytag
Scenario: Fetch the Weather of any Indian city (in degrees celcius)
	Given a valid API with key value pair to be passed
	When request to the API is sent
	Then the response from the API gets us the Temperature of the Indian City