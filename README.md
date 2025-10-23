# BlogWithAi

A complete blog website built with clean architecture using .NET 9, ASP.NET Core, and PostgreSQL database.

## Architecture

This project follows Clean Architecture principles with the following layers:

### Project Structure

```
BlogWithAi/
├── src/
│   ├── BlogWithAi.Domain/           # Domain entities and interfaces
│   ├── BlogWithAi.Application/      # Application services and DTOs
│   ├── BlogWithAi.Infrastructure/   # Data access and repository implementations
│   ├── BlogWithAi.API/             # REST API project
│   └── BlogWithAi.UI/              # MVC Web UI project
```

### Layers

1. **Domain Layer** (`BlogWithAi.Domain`)
   - Core business entities (Post, Category, Tag, Comment, Author)
   - Repository interfaces
   - No dependencies on other layers

2. **Application Layer** (`BlogWithAi.Application`)
   - Business logic and use cases
   - DTOs (Data Transfer Objects)
   - Service interfaces and implementations
   - Depends only on Domain layer

3. **Infrastructure Layer** (`BlogWithAi.Infrastructure`)
   - Database context (Entity Framework Core)
   - Repository implementations
   - PostgreSQL integration
   - Depends on Domain and Application layers

4. **API Layer** (`BlogWithAi.API`)
   - RESTful API endpoints
   - Controllers for Posts, Categories, Comments
   - Swagger/OpenAPI documentation
   - Depends on Application and Infrastructure layers

5. **UI Layer** (`BlogWithAi.UI`)
   - MVC web application
   - Views for blog posts, categories
   - Comment system
   - Depends on Application and Infrastructure layers

## Features

- ✅ Complete blog post management
- ✅ Categories and tags
- ✅ Multi-level comment system
- ✅ Author management
- ✅ View counter
- ✅ RESTful API
- ✅ MVC web interface
- ✅ PostgreSQL database
- ✅ Clean architecture
- ✅ Entity Framework Core with migrations

## Technologies

- .NET 9
- ASP.NET Core 9
- Entity Framework Core 9
- PostgreSQL (via Npgsql)
- Bootstrap 5 (UI)
- Swagger/OpenAPI (API documentation)

## Prerequisites

- .NET 9 SDK
- PostgreSQL server

## Setup and Configuration

### 1. Database Configuration

Update the connection string in both `appsettings.json` files:

**BlogWithAi.API/appsettings.json** and **BlogWithAi.UI/appsettings.json**:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=BlogWithAi;Username=postgres;Password=your_password"
  }
}
```

### 2. Create Database and Run Migrations

```bash
# Navigate to Infrastructure project
cd src/BlogWithAi.Infrastructure

# Create migration
dotnet ef migrations add InitialCreate --startup-project ../BlogWithAi.API

# Update database
dotnet ef database update --startup-project ../BlogWithAi.API
```

### 3. Run the API

```bash
cd src/BlogWithAi.API
dotnet run
```

The API will be available at `https://localhost:5001` (or the port specified in launchSettings.json).

### 4. Run the UI

```bash
cd src/BlogWithAi.UI
dotnet run
```

The web UI will be available at `https://localhost:5002` (or the port specified in launchSettings.json).

## API Endpoints

### Posts
- `GET /api/posts` - Get all posts
- `GET /api/posts/published` - Get published posts
- `GET /api/posts/{id}` - Get post by ID
- `GET /api/posts/slug/{slug}` - Get post by slug
- `GET /api/posts/category/{categoryId}` - Get posts by category
- `GET /api/posts/tag/{tagId}` - Get posts by tag
- `GET /api/posts/author/{authorId}` - Get posts by author
- `POST /api/posts` - Create new post
- `PUT /api/posts/{id}` - Update post
- `DELETE /api/posts/{id}` - Delete post

### Categories
- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get category by ID
- `GET /api/categories/slug/{slug}` - Get category by slug
- `POST /api/categories` - Create category
- `PUT /api/categories/{id}` - Update category
- `DELETE /api/categories/{id}` - Delete category

### Comments
- `GET /api/comments/post/{postId}` - Get approved comments for a post
- `POST /api/comments` - Create comment
- `PUT /api/comments/{id}/approve` - Approve comment
- `DELETE /api/comments/{id}` - Delete comment

## Development

### Build the solution
```bash
dotnet build
```

### Run tests (when implemented)
```bash
dotnet test
```

## Database Schema

The application uses the following main entities:

- **Posts**: Blog posts with title, content, slug, featured image, etc.
- **Categories**: Post categories
- **Tags**: Post tags (many-to-many with Posts)
- **Comments**: Hierarchical comments with replies
- **Authors**: Post authors

## License

This project is created for educational purposes.
