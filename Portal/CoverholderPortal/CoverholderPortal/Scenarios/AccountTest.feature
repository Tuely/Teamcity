Feature: AccountTest

@Regression
Scenario: Verify Login
	Given I am logged into Coverholder Portal
	Then I verify the user has logged in sucessfully

Scenario: Verify Logout
	Given I am logged into Coverholder Portal
	When I click the logout link
	Then I verify  the logout has been sucessful

Scenario: Verify Portal Logon screen - 'Strapline'
	Given I am on Coverholder Portal Logon Screen
	Then I verify the following text/strapline: 'The Delegated Underwriting Experts'

	Scenario: Verify Host Login 
	Given I am logged into Coverholder Portal Host
	Then I verify the user has logged in sucessfully