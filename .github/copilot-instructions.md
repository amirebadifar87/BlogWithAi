# Copilot Instructions for BlogWithAi

## Project Overview
BlogWithAi is a blog application built with AI assistance, focusing on creating a modern, scalable blogging platform using .NET technologies.

## Technology Stack
- **Framework**: .NET/ASP.NET Core
- **Language**: C#
- **Development**: Visual Studio / Visual Studio Code

## Coding Standards

### General Principles
- Follow C# coding conventions as outlined in Microsoft's official documentation
- Use meaningful, descriptive names for variables, methods, and classes
- Keep methods small and focused on a single responsibility
- Write self-documenting code with clear intent

### Naming Conventions
- Use PascalCase for class names, method names, and public properties
- Use camelCase for local variables and private fields
- Prefix private fields with underscore (e.g., `_fieldName`)
- Use meaningful names that clearly describe purpose

### Code Organization
- Keep related code together in appropriate namespaces
- Use folders to organize code by feature or layer
- Separate concerns (Models, Views, Controllers, Services, etc.)
- Follow layered architecture patterns

### Comments and Documentation
- Add XML documentation comments for public APIs
- Use inline comments sparingly, only when code intent is not clear
- Keep comments up-to-date with code changes
- Document complex algorithms or business logic

## Testing Requirements
- Write unit tests for business logic and services
- Follow Arrange-Act-Assert (AAA) pattern in tests
- Use descriptive test method names that explain what is being tested
- Aim for high test coverage on critical paths
- Mock external dependencies in unit tests

## Development Workflow

### Before Writing Code
1. Understand the requirement fully
2. Consider existing patterns in the codebase
3. Plan for testability and maintainability
4. Think about error handling and edge cases

### When Making Changes
1. Make minimal, focused changes
2. Ensure backward compatibility unless explicitly breaking
3. Update tests to reflect changes
4. Run all tests before committing
5. Follow the existing code style

### Error Handling
- Use try-catch blocks appropriately
- Log errors with sufficient context
- Return meaningful error messages to users
- Handle null references defensively

## Best Practices

### Security
- Never commit sensitive data (API keys, passwords, connection strings)
- Use environment variables for configuration
- Validate and sanitize all user inputs
- Follow OWASP security guidelines
- Use parameterized queries to prevent SQL injection

### Performance
- Use async/await for I/O operations
- Implement caching where appropriate
- Optimize database queries
- Use pagination for large datasets

### Database
- Use Entity Framework Core for data access
- Apply migrations for schema changes
- Use appropriate indexes for query performance
- Keep database operations in repository or service layer

### API Design
- Follow RESTful conventions
- Use appropriate HTTP status codes
- Version APIs when necessary
- Document endpoints with clear descriptions

## Project-Specific Guidelines

### Blog Features
When implementing blog functionality, consider:
- Post creation, editing, and deletion
- User authentication and authorization
- Comments and interactions
- Categories and tags
- Search functionality
- Rich text editing

### AI Integration
When integrating AI features:
- Keep AI logic modular and testable
- Handle AI service failures gracefully
- Consider rate limiting and costs
- Provide fallback mechanisms

## File Structure
```
BlogWithAi/
├── src/              # Source code
├── tests/            # Test projects
├── docs/             # Documentation
└── .github/          # GitHub-specific files
```

## Build and Test Commands

### Building the Project
```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Build in Release mode
dotnet build --configuration Release
```

### Running Tests
```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity detailed

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Running the Application
```bash
# Run the application in development mode
dotnet run --project src/BlogWithAi

# Run with hot reload
dotnet watch run --project src/BlogWithAi
```

## Development Environment Setup

### Prerequisites
- **.NET SDK**: Version 6.0 or higher (check with `dotnet --version`)
- **IDE**: Visual Studio 2022, Visual Studio Code, or JetBrains Rider
- **Git**: For version control
- **SQL Server** (or SQL Server Express): For database operations

### Initial Setup
1. Clone the repository
2. Navigate to the project directory
3. Restore NuGet packages: `dotnet restore`
4. Update database: `dotnet ef database update` (if using EF migrations)
5. Set up environment variables (copy `.env.example` to `.env` if available)
6. Build the project: `dotnet build`
7. Run the application: `dotnet run`

### Environment Variables
Create a `.env` file or use user secrets for local development:
- Database connection strings
- API keys for external services
- Application-specific configuration

Use the Secret Manager tool for sensitive data:
```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your-connection-string"
```

## Version Control Guidelines

### Branching Strategy
- **main/master**: Production-ready code
- **develop**: Integration branch for features
- **feature/**: New features (`feature/add-user-authentication`)
- **bugfix/**: Bug fixes (`bugfix/fix-login-issue`)
- **hotfix/**: Urgent production fixes

### Commit Messages
Follow conventional commits format:
- `feat:` New feature
- `fix:` Bug fix
- `docs:` Documentation changes
- `style:` Code style changes (formatting)
- `refactor:` Code refactoring
- `test:` Adding or updating tests
- `chore:` Maintenance tasks

Example: `feat: add user registration functionality`

### Pull Request Guidelines
- Create descriptive PR titles
- Reference related issues
- Ensure all tests pass
- Request reviews from team members
- Keep PRs focused and reasonably sized

## Common Pitfalls and Troubleshooting

### Database Issues
- **Problem**: Migration errors
  - **Solution**: Ensure database connection string is correct and database is accessible
  - Check for pending migrations: `dotnet ef migrations list`

- **Problem**: Connection timeout
  - **Solution**: Verify SQL Server is running and connection string includes proper timeout settings

### Build Issues
- **Problem**: Package restore failures
  - **Solution**: Clear NuGet cache: `dotnet nuget locals all --clear`
  - Check internet connection and NuGet sources

- **Problem**: Assembly conflicts
  - **Solution**: Clean and rebuild: `dotnet clean && dotnet build`

### Runtime Issues
- **Problem**: Configuration missing
  - **Solution**: Verify appsettings.json and environment variables are properly set

- **Problem**: Port already in use
  - **Solution**: Change port in launchSettings.json or stop the conflicting process

### Testing Issues
- **Problem**: Tests failing locally but passing in CI
  - **Solution**: Ensure test environment matches CI environment
  - Check for timing issues or external dependencies

## Documentation and Resources

### Internal Documentation
- **README.md**: Project overview and quick start guide
- **docs/**: Detailed documentation (if available)
- **Wiki**: Additional guides and tutorials (if available)

### External Resources
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [.NET API Browser](https://docs.microsoft.com/dotnet/api)

### Getting Help
- Check existing issues and discussions in the repository
- Review pull requests for examples of similar changes
- Consult team members for project-specific questions
- Use inline code comments to explain complex logic

## Additional Notes
- Keep dependencies up-to-date
- Document major architectural decisions
- Consider accessibility in UI development
- Write code that is easy to maintain and extend
- Prioritize code clarity over cleverness
- Always review your changes before committing
- Use meaningful branch names that describe the work
- Keep commits atomic and focused on a single concern
