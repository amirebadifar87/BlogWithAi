# Setup Guide

This guide will help you set up and run the BlogWithAi application.

## Prerequisites

1. **.NET 9 SDK**: Download from [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
2. **PostgreSQL**: Download from [https://www.postgresql.org/download/](https://www.postgresql.org/download/)
3. **IDE** (optional but recommended):
   - Visual Studio 2022 (v17.8 or later)
   - Visual Studio Code with C# extension
   - JetBrains Rider

## Step 1: Clone the Repository

```bash
git clone https://github.com/amirebadifar87/BlogWithAi.git
cd BlogWithAi
```

## Step 2: Configure PostgreSQL

### Install and Start PostgreSQL

**Windows:**
```bash
# After installation, PostgreSQL should start automatically
# Check if it's running in Services
```

**macOS (using Homebrew):**
```bash
brew install postgresql@15
brew services start postgresql@15
```

**Linux:**
```bash
sudo apt-get install postgresql postgresql-contrib
sudo service postgresql start
```

### Create Database

```bash
# Connect to PostgreSQL
psql -U postgres

# Create database
CREATE DATABASE "BlogWithAi";

# Exit psql
\q
```

## Step 3: Update Connection String

Update the connection string in both projects:

**src/BlogWithAi.API/appsettings.json**
**src/BlogWithAi.UI/appsettings.json**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=BlogWithAi;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

Replace `YOUR_PASSWORD` with your PostgreSQL password.

## Step 4: Install EF Core Tools

```bash
dotnet tool install --global dotnet-ef
```

Or update if already installed:
```bash
dotnet tool update --global dotnet-ef
```

## Step 5: Create Database Migration

```bash
cd src/BlogWithAi.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../BlogWithAi.API
```

## Step 6: Apply Migration to Database

```bash
dotnet ef database update --startup-project ../BlogWithAi.API
```

This will create all the necessary tables in your PostgreSQL database.

## Step 7: Run the Applications

### Option 1: Run API and UI Separately

**Terminal 1 - Run the API:**
```bash
cd src/BlogWithAi.API
dotnet run
```

The API will be available at: `https://localhost:5001` or `http://localhost:5000`

**Terminal 2 - Run the UI:**
```bash
cd src/BlogWithAi.UI
dotnet run
```

The UI will be available at: `https://localhost:5002` or `http://localhost:5003`

### Option 2: Run from Solution (Visual Studio)

1. Open `BlogWithAi.sln` in Visual Studio
2. Right-click on the solution → Properties
3. Select "Multiple startup projects"
4. Set both `BlogWithAi.API` and `BlogWithAi.UI` to "Start"
5. Click F5 to run

## Step 8: Verify Installation

### Test API
1. Navigate to `https://localhost:5001/openapi/v1.json` to view the OpenAPI specification
2. Or use the Swagger UI (if available in development)

### Test UI
1. Navigate to `https://localhost:5002`
2. You should see the blog homepage

## Step 9: Seed Sample Data (Optional)

To add sample data to your database, you can either:

### Option A: Use the DbInitializer

Add this code to your `Program.cs` in the API project:

```csharp
// After var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BlogDbContext>();
    DbInitializer.Initialize(context);
}
```

### Option B: Manual SQL Insert

Connect to your PostgreSQL database and run the SQL commands to insert sample data.

## Troubleshooting

### Connection Issues

**Problem**: Cannot connect to PostgreSQL
**Solution**: 
- Verify PostgreSQL is running: `sudo service postgresql status` (Linux) or check Services (Windows)
- Check the connection string in appsettings.json
- Ensure the database exists
- Verify username and password

### Migration Issues

**Problem**: Migrations fail
**Solution**:
- Ensure PostgreSQL is running
- Verify connection string
- Check that you're in the correct directory
- Try: `dotnet ef database drop` and recreate

### Port Conflicts

**Problem**: Port already in use
**Solution**:
- Edit `Properties/launchSettings.json` in API and UI projects
- Change the ports in the `applicationUrl` setting

### Build Issues

**Problem**: Build fails
**Solution**:
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

## Verify Everything Works

1. **API Test**: 
   - Visit `https://localhost:5001/api/posts/published`
   - You should see a JSON response (empty array if no data)

2. **UI Test**:
   - Visit `https://localhost:5002`
   - You should see the blog homepage

3. **Database Test**:
   ```bash
   psql -U postgres -d BlogWithAi
   \dt  # List all tables
   SELECT * FROM "Posts";  # View posts
   ```

## Next Steps

Now that your application is running:

1. Create your first blog post using the API
2. Add categories and tags
3. Test the comment system
4. Customize the UI styling
5. Add authentication (future enhancement)

## Support

For issues or questions:
- Check the README.md for general information
- Review the code documentation
- Check PostgreSQL and .NET logs for error messages
