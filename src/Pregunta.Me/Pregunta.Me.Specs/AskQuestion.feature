Feature: Ask a Question
	As an Inquirer, having selected an Expert, 
	I want to ask a question to the Expert so that 
	I can get an answer to my inquiry.

@mytag
Scenario: Ask an Expert a Question
	Given that I formulate a Question
	And select a valid Expert to answer it
	When I submit the Question
	Then the system produces a Question Receipt

Scenario: Show me my Question Receipts
	Given A valid Inquirer
	And I have Question Receipts
	When I invoke get list of Receipts
	Then the system produces a list of Question Receipts
