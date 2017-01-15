Feature: Search for an Expert	
	As an Inquirer, I want to search for an Expert 
	in a given Area of Expertiese
@mytag
Scenario: Search for an Expert within an Area of Expertise
	Given A valid Inquirer
	And Area of Expretise to search
	When I invoke search
	Then I can obtain the list of Experts in that Area of Expertise
