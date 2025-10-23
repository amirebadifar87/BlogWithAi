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

## Additional Notes
- Keep dependencies up-to-date
- Document major architectural decisions
- Consider accessibility in UI development
- Write code that is easy to maintain and extend
- Prioritize code clarity over cleverness
