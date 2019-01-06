Feature: PostActions
	In order to check what we can do with Posts
	we try to add, get, change and delete it

@api
Scenario Outline: 1Add a post
	Given I have post endpoint ready with post id <id>
	When I send a post request
	Then the post should be added and id <id> the same as sent
Examples:
| id |
| 2222   |
| 4442   |



@api
Scenario Outline: 2Retrieve a post
	Given I have get endpoint ready with post id <id>
	When I send a get request
	Then the post with id <id> should be retrieved without issues
Examples:
| id |
| 2222   |
| 4442   |

@api
Scenario Outline: 3Update a post
	Given I have put endpoint ready with post id <id> and new <name>
	When I send a put request
	Then the post should be updated and id <id> the <name> should be changed
Examples:
| id   | name |
| 2222 |   bzz   |
| 4442 |  beee    |

@api
Scenario Outline: 4Delete a post
	Given I have delete endpoint ready with post id <id>
	When I send a delete request
	Then the post should be deleted
	And the id <id> should not exists any more
Examples:
| id |
| 2222   |
| 4442   |



