# Animes Forum README

## Welcome to Animes Forum

Animes Forum is a public discussion platform dedicated to anime enthusiasts. It offers a vibrant community for sharing, discussing, and exploring various aspects of anime culture.

### Prerequisites

To get started with the Animes Forum, ensure you have the following installed:

- Visual Studio (or Visual Studio Code)
- SQL Server or SQL Server Express
- .NET SDK

### Database Configuration

1. **Configure SQL Server Connection:**
   - Navigate to `appsettings.json` in the AnimesForum directory.
   - Update the SQL Server database connection string:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "your_connection_string_here"
     }
     ```

2. **Create the Database:**
   - In Visual Studio, go to the Package Manager Console.
   - Run `Update-Database`. This applies all pending migrations and creates the database.

### Running the Project

1. Open the Animes Forum project in Visual Studio.
2. Set the AnimesForum project as the startup project.
3. Press `F5` to start the project.
4. Access the application at `https://localhost:PORT`. Replace `PORT` with the actual port number (commonly 5001 for HTTPS or 5000 for HTTP).

### Updating Migrations

If there are changes to the data models, migrations need to be updated:

1. Open Package Manager Console in Visual Studio.
2. Create a new migration with `Add-Migration MigrationName`. Replace `MigrationName` with a descriptive name.
3. Apply the migration to the database with `Update-Database`.

### Contributing

Contributions are welcome! You can contribute by opening issues, submitting pull requests, and helping enhance the forum's functionality and discussions.

### License

This project is licensed under the MIT License. For more details, see the LICENSE file in the project directory.
