Feature: Admin
	In order to get users defined in Pregunta.Me
	As an Administrator
	I want to create Experts or Inquirers in the system.

@mytag
Scenario: Add an Expert user to the system
	Given a well formed AdminService
	When I create a new Expert User with it's required properties
	Then a new Expert is created with IsValid property = true
	And an ExpertId property != 0

