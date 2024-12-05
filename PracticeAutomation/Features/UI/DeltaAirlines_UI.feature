Feature: DeltaAirlines_UI

Background: Navigate to home page
	Given user is on the Delta Airlines homepage


Scenario: Search for a flight
	When user searches a flight from 'MNL' to 'LAX'
	Then available flights should be shown

