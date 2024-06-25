Feature: MultiDemo

A short summary of the feature

@nonweb
Scenario: Fail Scenario
	Given Some valid data 
	When some 'string' data
	When some '1' data
	When some another 1212323 data
	Then some another Helllllllo data
	When switch to tab having Title1 as title
	When switch to tab having 1 as index

	Then Fail step
	
