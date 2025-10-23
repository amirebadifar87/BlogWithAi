# Security Considerations

This document outlines security considerations for the BlogWithAi application.

## Current Security Status

### ✅ Implemented Security Features

1. **Clean Architecture**: Separation of concerns prevents direct database access from presentation layers
2. **Entity Framework Core**: Parameterized queries prevent SQL injection
3. **Input Validation**: Model validation in DTOs and entities
4. **Null Safety**: Nullable reference types enabled in all projects
5. **HTTPS**: Enforced in both API and UI projects
6. **Dependency Security**: All NuGet packages verified against GitHub Advisory Database

### ⚠️ Known Security Considerations

#### 1. HTML Content Rendering (Intentional)
**Location**: `BlogWithAi.UI/Views/Blog/Post.cshtml` (line 34)

```csharp
@Html.Raw(Model.Content)
```

**Risk**: Potential Cross-Site Scripting (XSS) if post content contains malicious scripts.

**Justification**: This is intentional to allow rich HTML content in blog posts.

**Mitigation Options**:
- Content should be sanitized before storage (implement HTML sanitization library)
- Only trusted authors should be able to create posts
- Consider implementing a WYSIWYG editor with built-in sanitization
- Recommended library: [HtmlSanitizer](https://www.nuget.org/packages/HtmlSanitizer)

**Example Implementation**:
```csharp
// In PostService.CreatePostAsync
using Ganss.Xss;
var sanitizer = new HtmlSanitizer();
post.Content = sanitizer.Sanitize(createPostDto.Content);
```

#### 2. No Authentication/Authorization
**Status**: Not yet implemented

**Risks**:
- Anyone can create, update, or delete posts via API
- No user management or role-based access control
- Comments are not moderated by default (require approval)

**Recommended Implementation**:
- Add ASP.NET Core Identity for user management
- Implement JWT tokens for API authentication
- Add role-based authorization (Admin, Author, Reader)
- Protect sensitive endpoints with `[Authorize]` attributes

**Example**:
```csharp
[Authorize(Roles = "Admin,Author")]
[HttpPost]
public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto createPostDto)
```

#### 3. CORS Policy
**Location**: `BlogWithAi.API/Program.cs`

```csharp
policy.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
```

**Risk**: Allows requests from any origin, which is acceptable for development but should be restricted in production.

**Production Recommendation**:
```csharp
policy.WithOrigins("https://yourdomain.com")
      .AllowAnyMethod()
      .AllowAnyHeader();
```

#### 4. No Rate Limiting
**Status**: Not implemented

**Risk**: API endpoints can be flooded with requests, potentially causing DoS.

**Recommendation**: Implement rate limiting using AspNetCoreRateLimit or similar library.

#### 5. Database Connection String in appsettings.json
**Risk**: Credentials stored in plain text in configuration files.

**Production Recommendations**:
- Use environment variables
- Use Azure Key Vault or similar secret management
- Use Azure SQL Managed Identity
- Never commit connection strings with real passwords to version control

**Example**:
```csharp
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(
        Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") 
        ?? builder.Configuration.GetConnectionString("DefaultConnection")));
```

#### 6. Comment Content
**Location**: Comment submission in views

**Risk**: User-submitted comments could contain malicious content.

**Current Protection**: Comments require approval before display (IsApproved flag).

**Additional Recommendations**:
- Sanitize comment content before storage
- Implement spam detection
- Add CAPTCHA to comment form
- Limit comment length

### 🔒 Recommended Security Enhancements

#### Priority 1 (Critical for Production)
1. **Implement Authentication and Authorization**
   - Add ASP.NET Core Identity
   - Implement JWT authentication for API
   - Add role-based access control

2. **Add HTML Sanitization**
   ```bash
   dotnet add package HtmlSanitizer
   ```

3. **Secure Configuration**
   - Move connection strings to environment variables
   - Use Azure Key Vault or similar for secrets

4. **Update CORS Policy**
   - Restrict to specific origins in production

#### Priority 2 (Important)
5. **Implement Rate Limiting**
   ```bash
   dotnet add package AspNetCoreRateLimit
   ```

6. **Add Input Validation**
   - Enhance DTOs with data annotations
   - Add custom validation logic
   - Validate file uploads if implemented

7. **Implement CSRF Protection**
   - Add antiforgery tokens to forms
   - Validate tokens on POST requests

#### Priority 3 (Nice to Have)
8. **Add Logging and Monitoring**
   - Log security events
   - Monitor for suspicious activity
   - Implement Application Insights or similar

9. **Add Content Security Policy (CSP)**
   ```csharp
   app.Use(async (context, next) =>
   {
       context.Response.Headers.Add("Content-Security-Policy", 
           "default-src 'self'; script-src 'self'; style-src 'self' 'unsafe-inline';");
       await next();
   });
   ```

10. **Implement API Versioning**
    - Allows for breaking changes without affecting existing clients

## Security Testing Recommendations

1. **Static Analysis**
   - Enable security analyzers in project
   - Run SonarQube or similar tools

2. **Dependency Scanning**
   - Regularly check for vulnerable packages
   - Use `dotnet list package --vulnerable`

3. **Penetration Testing**
   - Test for common vulnerabilities (OWASP Top 10)
   - Verify input validation
   - Test authentication and authorization

4. **Code Review**
   - Review all user input handling
   - Verify SQL query construction
   - Check for sensitive data exposure

## Compliance Considerations

- **GDPR**: If collecting user data, ensure compliance
  - Add privacy policy
  - Implement data deletion
  - Add consent mechanisms

- **CCPA**: Similar to GDPR for California residents

- **Cookie Consent**: If using cookies, implement consent banner

## Quick Security Checklist for Production

- [ ] Authentication implemented
- [ ] Authorization configured
- [ ] HTML content sanitized
- [ ] CORS policy restricted
- [ ] Rate limiting enabled
- [ ] HTTPS enforced
- [ ] Connection strings secured
- [ ] Sensitive data not logged
- [ ] Error messages don't expose system details
- [ ] Security headers configured
- [ ] CSRF protection enabled
- [ ] Input validation comprehensive
- [ ] Dependencies up to date
- [ ] Security testing completed

## Resources

- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [ASP.NET Core Security](https://docs.microsoft.com/aspnet/core/security/)
- [Entity Framework Core Security](https://docs.microsoft.com/ef/core/querying/sql-queries)
- [Azure Security Best Practices](https://docs.microsoft.com/azure/security/fundamentals/best-practices-and-patterns)

## Reporting Security Issues

If you discover a security vulnerability, please email security@example.com instead of using the public issue tracker.
