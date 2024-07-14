# BookstoreApi
This is a simple web api that process a book store.
It has developed using .NET Core, Microsoft Visual Studio Community 2022 (64-bit) and SQL SERVER EXPRESS.
Data annotations have been used in order to define validation rules, format strings, and other metadata in the model properties. In this way we can simplify the code and make it easier to maintain.
The object-relational mapping (ORM) framework that is used is the Entity Framework Core (6.0.0). It is a lightweight and cross-platform version of Entity Framework (EF).
Basic Authentication is used. Hardcoded username and password are used for simplicity. In a real-world application, the credentials have to be validated against a user store such as a database.
Please, use the following credentials:
  Username:marine
  Password:tours
  

In order to run it follow the following steps:
1. Open the solution using Visual Studio.
2. In the appsettings.json file of the Bookstore project the connectionString of your database must be put in the DefaultConnection property.
3. Go to package Manager Console
4. Go to the folder that there is your project using the cd command.
5. Run :  dotnet ef database update. This will update the database to the last migration.
6. Run the BookstoreApi.
7. The web api is running and can be used.
   

The documentation for the API endpoint is available using the Swagger UI. It is available in the https://localhost:5001/swagger/index.html. In this you will find all the information about the calls and the schemas of the web api. At the moment basic authentication is used, please follow the steps:
1. Click the "Authorize" button.
2. Enter the username and password (`marine` and `tours`).
3. Test the endpoints.

The unit tests are available in the BookstoreApi.Tests project.
