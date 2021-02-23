Feature: SystemSettings

Background:
	Given I am logged into Coverholder Portal

@Regression
Scenario: Edit API details via system settings
	Given I navigate into system settings page
	When I edit Api details api url as 'https://editurl'
	Then I verify the updated Api details 'https://editurl'