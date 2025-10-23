using BlogWithAi.Domain.Entities;
using BlogWithAi.Infrastructure.Data;

namespace BlogWithAi.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(BlogDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if database is already seeded
        if (context.Authors.Any())
        {
            return; // DB has been seeded
        }

        // Seed Authors
        var authors = new Author[]
        {
            new Author
            {
                Name = "John Doe",
                Email = "john@example.com",
                Bio = "Passionate blogger and technology enthusiast",
                Avatar = "https://via.placeholder.com/150",
                CreatedAt = DateTime.UtcNow
            },
            new Author
            {
                Name = "Jane Smith",
                Email = "jane@example.com",
                Bio = "Writer and software developer",
                Avatar = "https://via.placeholder.com/150",
                CreatedAt = DateTime.UtcNow
            }
        };
        context.Authors.AddRange(authors);
        context.SaveChanges();

        // Seed Categories
        var categories = new Category[]
        {
            new Category
            {
                Name = "Technology",
                Slug = "technology",
                Description = "Latest technology news and tutorials",
                CreatedAt = DateTime.UtcNow
            },
            new Category
            {
                Name = "Programming",
                Slug = "programming",
                Description = "Programming tips and best practices",
                CreatedAt = DateTime.UtcNow
            },
            new Category
            {
                Name = "Web Development",
                Slug = "web-development",
                Description = "Web development guides and resources",
                CreatedAt = DateTime.UtcNow
            }
        };
        context.Categories.AddRange(categories);
        context.SaveChanges();

        // Seed Tags
        var tags = new Tag[]
        {
            new Tag { Name = "C#", Slug = "csharp", CreatedAt = DateTime.UtcNow },
            new Tag { Name = ".NET", Slug = "dotnet", CreatedAt = DateTime.UtcNow },
            new Tag { Name = "ASP.NET Core", Slug = "aspnet-core", CreatedAt = DateTime.UtcNow },
            new Tag { Name = "Entity Framework", Slug = "entity-framework", CreatedAt = DateTime.UtcNow },
            new Tag { Name = "PostgreSQL", Slug = "postgresql", CreatedAt = DateTime.UtcNow },
            new Tag { Name = "Clean Architecture", Slug = "clean-architecture", CreatedAt = DateTime.UtcNow }
        };
        context.Tags.AddRange(tags);
        context.SaveChanges();

        // Seed Posts
        var posts = new Post[]
        {
            new Post
            {
                Title = "Getting Started with .NET 9",
                Slug = "getting-started-with-dotnet-9",
                Content = "<p>Welcome to our comprehensive guide on .NET 9! This latest version brings exciting new features and improvements.</p><p>In this post, we'll explore the key features and show you how to get started with your first .NET 9 application.</p>",
                Excerpt = "Learn about the new features in .NET 9 and how to get started",
                IsPublished = true,
                PublishedAt = DateTime.UtcNow.AddDays(-5),
                ViewCount = 150,
                AuthorId = authors[0].Id,
                CategoryId = categories[0].Id,
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Post
            {
                Title = "Clean Architecture in ASP.NET Core",
                Slug = "clean-architecture-in-aspnet-core",
                Content = "<p>Clean Architecture is a software design philosophy that separates the elements of a design into ring levels.</p><p>In this article, we'll implement clean architecture in an ASP.NET Core application.</p>",
                Excerpt = "Implementing clean architecture principles in ASP.NET Core applications",
                IsPublished = true,
                PublishedAt = DateTime.UtcNow.AddDays(-3),
                ViewCount = 200,
                AuthorId = authors[1].Id,
                CategoryId = categories[1].Id,
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },
            new Post
            {
                Title = "PostgreSQL with Entity Framework Core",
                Slug = "postgresql-with-entity-framework-core",
                Content = "<p>PostgreSQL is a powerful, open-source relational database system.</p><p>Learn how to integrate PostgreSQL with Entity Framework Core in your .NET applications.</p>",
                Excerpt = "A guide to using PostgreSQL with EF Core",
                IsPublished = true,
                PublishedAt = DateTime.UtcNow.AddDays(-1),
                ViewCount = 75,
                AuthorId = authors[0].Id,
                CategoryId = categories[2].Id,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            }
        };
        context.Posts.AddRange(posts);
        context.SaveChanges();

        // Add tags to posts
        posts[0].Tags.Add(tags[0]); // C#
        posts[0].Tags.Add(tags[1]); // .NET
        posts[1].Tags.Add(tags[2]); // ASP.NET Core
        posts[1].Tags.Add(tags[5]); // Clean Architecture
        posts[2].Tags.Add(tags[3]); // Entity Framework
        posts[2].Tags.Add(tags[4]); // PostgreSQL
        context.SaveChanges();

        // Seed Comments
        var comments = new Comment[]
        {
            new Comment
            {
                Content = "Great article! Very helpful for beginners.",
                AuthorName = "Reader One",
                AuthorEmail = "reader1@example.com",
                PostId = posts[0].Id,
                IsApproved = true,
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            },
            new Comment
            {
                Content = "Thanks for sharing this comprehensive guide.",
                AuthorName = "Reader Two",
                AuthorEmail = "reader2@example.com",
                PostId = posts[1].Id,
                IsApproved = true,
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },
            new Comment
            {
                Content = "Could you provide more examples?",
                AuthorName = "Reader Three",
                AuthorEmail = "reader3@example.com",
                PostId = posts[1].Id,
                IsApproved = true,
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            }
        };
        context.Comments.AddRange(comments);
        context.SaveChanges();
    }
}
