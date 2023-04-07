# Federal Training Request Form Project (Backend)

Frontend code for the project can be found at this link: (https://github.com/Jitahidi/Customer_Training/tree/main/material_table).

## Ojective

The objective of this project was to create a streamlined full-stack application based on the Federal Employee Training Form (SF-182), 
which can be found at this link: (https://www.opm.gov/forms/pdf_fill/sf182.pdf). The front-end portion of the project was developed using React, 
while the back-end portion was built with the Entity Framework Code First Library (ASP.NET Core) in C# and PostgreSQL. The project emphasizes the creation of a 
form to gather trainee information and training course data, subsequently storing the collected data in a database.

## Summary of the Backend Code

The code provided is for a web application that manages employee training data. The application uses ASP.NET Core and Entity Framework Core with a PostgreSQL database. 
The main components of the application are the controllers, data context, and class files.

### `Controllers`

The EmployeesController and RequestsController classes handle the API endpoints for managing employee and training request data. They provide actions for creating, retrieving, updating, and deleting records.

### `Data Contexts`

CustomerTrainingDataContext.cs: This class inherits from DbContext and is responsible for managing the connection to the PostgreSQL database. It defines the two DbSet properties for Employee and Request data.

CustomerTrainingDataContextFactory.cs: This class is responsible for creating the data context with the appropriate connection string. It reads the connection string from the environment variable DATABASE_URL (e.g., when deployed on Heroku).

### `Classes`

Employee.cs and Request.cs classes contain the properties and columns for the database tables.

### `Appsettings`

appsettings.json: This file contains the application settings, including the connection string for the PostgreSQL database (for local development only).

### `Program.cs`

Program.cs: This file contains the main entry point for the application. It sets up the web host and runs the application. 

