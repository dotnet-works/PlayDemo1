@allure.label.epic:WebInterface
Feature: SocialNewUser1

A short summary of the feature

Scenario: SocialNet12
open a demo page
   Given I navigate to 'https://demo.opensource-socialnetwork.org/'
   When enter first name data
   And click on 'dob' element and enter birtdate as "15 Oct. 2000"
   Then verify birthdate should be in dd/mm/yyyy format
   When enter new user data
   When open new tab and navigate to "https://www.yopmail.com"
   #When go to newuser yopmail inbox
   #And navigates to social network activation page
   #And login with credentials using username and password

@allure.label.story:AdminLogin
@wip
Scenario: Login As Admin
   Given I navigate to 'https://demo.opensource-socialnetwork.org/'
   When login as admin using 'administrator' and 'administrator' credentials
   And wait for 8 secs
   And allure sample attachments

@allure.label.story:FailTest
@wip
Scenario: FailTest
   Given I navigate to 'https://demo.opensource-socialnetwork.org/'
   When login as admin using 'administrator' and 'administrator' credentials
   And allure sample attachments
   Then Fail step