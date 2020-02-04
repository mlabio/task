Setup:

1. On nuget package manager console select CRUD.Project.DAL and type these commands:
 - Update-Database -Context IdentityContext
 - Update-Database -Context DatabaseContext
2. To access the swagger, just add "/swagger" to the url after running the project
3. In order to use the endpoints, user must have an account for authentication
4. For authorization on swagger after logging in a token is returned:
use the token for authorization by simply typing this Bearer [space] Token to authorization value section of swagger