# Animes Forum

Welcome to Animes Forum, a public discussion forum for anime enthusiasts!

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) (or [Visual Studio Code](https://code.visualstudio.com/))
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [.NET SDK](https://dotnet.microsoft.com/download)

## Database Configuration

1. Open the `appsettings.json` file in `AnimesForum` and configure the SQL Server database connection.

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "your_connection_string_here"
   }
In Visual Studio, open the Package Manager Console and run the following command to create the database:

Update-Database
This will apply all pending migrations and create the database.

Running the Project
Open the project in Visual Studio.

Ensure that the AnimesForum project is set as the startup project.

Press F5 to start the project.

The application should be running, and you can access it at https://localhost:PORT in your web browser, where PORT is the port the project is running on (usually 5001 for HTTPS or 5000 for HTTP).

Updating Migrations
If you make changes to the data models, you'll need to update migrations to reflect those changes in the database. Follow these steps:

In Visual Studio, open the Package Manager Console.

Run the following command to create a new migration:

sql
Copy code
Add-Migration MigrationName
Replace MigrationName with a descriptive name for the migration.

Run the following command to apply the migration to the database:

mathematica
Copy code
Update-Database
This will apply the new migration to the database.

Contributing
Feel free to contribute to this project. You can open issues, submit pull requests, and help improve the discussion forum.

License
This project is licensed under the MIT License. See the LICENSE file for more details.
