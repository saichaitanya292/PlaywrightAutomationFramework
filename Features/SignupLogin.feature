Feature: User Signup and Login

  Scenario: Create new user and verify login
    Given User navigates to signup page
    When User enters name and email
    And User completes account registration
    Then User should be logged in successfully
