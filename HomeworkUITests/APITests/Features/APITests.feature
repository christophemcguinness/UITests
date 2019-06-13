Feature: APITests
	USING THE https://reqres.in/ TEST API
	CREATE A NUMBER OF SPECFLOW SCENARIOS.

Scenario: Page Endpoint Returns 200
	Given Set the API EndPoint to "api/users?page=2"
	And Set the Request Type as GET
	And Execute the request call
	Then Check Status Code is 200

Scenario: Page returns page 2 and confirm 3 users are returned
	Given Set the API EndPoint to "api/users?page=2"
	And Set the Request Type as GET
	And Execute the request call
	Then Check number of user is 3

Scenario: Confirm user 2 name is Janet
	Given Set the API EndPoint to "api/users/2"
	And Set the Request Type as GET
	And Execute the request call
	Then Check Users first name is "Janet"

Scenario: Create New User
	Given Set the API EndPoint to "api/users"
	And Set the Request Type as Post
	And I set body to "name" is "morpheus" and "job" is "leader"
	And Execute the request call
	Then Check Status Code is 201

Scenario: Update User by Id 2 using put
	Given Set the API EndPoint to "api/users/2"
	And Set the Request Type as Put
	And I set body to "name" is "morpheus" and "job" is "zion resident"
	And Execute the request call
	Then Check Status Code is 200
	Then Check Users name is "morpheus" 

Scenario: Delete User
	Given Set the API EndPoint to "api/users/2"
	And Set the Request Type as Delete
	And Execute the request call
	Then Check Status Code is 204

Scenario: Test Registering a user	
	Given Set the API EndPoint to "api/register"
	And Set the Request Type as Post
	And I set body to "email" is "eve.holt@reqres.in" and "password" is "pistol"
	And Execute the request call
	Then Check Status Code is 200
	Then Then check id is 4

Scenario: Test Login
	Given Set the API EndPoint to "api/login"
	And Set the Request Type as Post
	And I set body to "email" is "eve.holt@reqres.in" and "password" is "cityslicka"
	And Execute the request call
	Then Check Status Code is 200
	Then Then check token is not null
