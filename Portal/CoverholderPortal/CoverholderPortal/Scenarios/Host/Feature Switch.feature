Feature: Feature Switch

Background:
	Given I am logged into Coverholder Portal Host

@Regression
Scenario: Verify Admin can enable or disable features for tenant
	When I edit an application edition
	Then I can enable or disable features for tenant

Scenario: Enable Release Note Fetaures as host and Verify the tenant can see the Release Note features
	When I edit an application edition
	And I enable Release Note feature
	And I am logged into Coverholder Portal
	Then I verify Release Note features are showing for the user

Scenario: Disable Release Note Fetaures as host and Verify the tenant can't see the Release Note features
	When I edit an application edition
	And I disable Release Note feature
	And I am logged into Coverholder Portal
	Then I verify Release Note features are not showing for the user

Scenario: Enable Setup Fetaures as host and Verify the tenant can see the setup features
	When I edit an application edition
	And I enable setup feature
	And I am logged into Coverholder Portal
	Then I verify Setup features are showing for the user

	Scenario: Disable Setup Fetaures as host and Verify the tenant can't see the setup features
	When I edit an application edition
	And I disable setup feature
	And I am logged into Coverholder Portal
	Then I verify Setup features are not showing for the user

Scenario: Verify the tenant can see only enabled features for Organization Units
	When I edit an application edition
	And I disable the Administration feature for 'Organization Units'
	And I am logged into Coverholder Portal
	Then I verify Administration - 'Organization Units' features are not showing for the user