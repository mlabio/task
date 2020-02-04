Setup:
1. Change appsettings.json pointing to your local database
2. On nuget package manager console select CRUD.Project.DAL and type these commands:
 - Update-Database -Context IdentityContext
 - Update-Database -Context DatabaseContext
3. To access the swagger, just add "/swagger" to the url after running the project
4. In order to use the endpoints, user must have an account for authentication
5. For authorization on swagger after logging in a token is returned:
use the token for authorization by simply typing this Bearer [space] Token to authorization value section of swagger

