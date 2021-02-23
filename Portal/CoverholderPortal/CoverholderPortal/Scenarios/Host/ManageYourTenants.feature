Feature: ManageYourTenants

Background:
	Given I am logged into Coverholder Portal Host

@Regression
Scenario: Create a new tenant
	When I create a new tenant 'TestTenant' and 'test@test.com'
	And I enter the API url and authentication details as 'https://Apitesturl' 'https://Apitesturl' 'authCode'
	Then I verify the tenant has created 'TestTenant'

Scenario: Edit an existing tenant
	When I create a new tenant 'TestTenant' and 'test@test.com'
	And I enter the API url and authentication details as 'https://Apitesturl' 'https://Apitesturl' 'authCode'
	And I search for tenant details 'TestTenant'
	And I edit tenant details 'EditTenant'
	Then I verify the tenant has created 'EditTenant'

Scenario: Edit Api details for an existing tenant
	When I create a new tenant 'TestTenant' and 'test@test.com'
	And I enter the API url and authentication details as 'https://Apitesturl' 'https://Apitesturl' 'authCode'