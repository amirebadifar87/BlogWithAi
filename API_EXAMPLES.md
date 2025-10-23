# API Usage Examples

This document provides examples of how to use the BlogWithAi REST API.

## Base URL

```
https://localhost:5001/api
```

## Authentication

Currently, the API does not require authentication. This can be added in future versions.

## Posts

### Get All Published Posts

```bash
curl -X GET "https://localhost:5001/api/posts/published" \
     -H "accept: application/json"
```

**Response:**
```json
[
  {
    "id": 1,
    "title": "Getting Started with .NET 9",
    "slug": "getting-started-with-dotnet-9",
    "content": "<p>Welcome to our comprehensive guide...</p>",
    "excerpt": "Learn about the new features in .NET 9",
    "featuredImage": null,
    "isPublished": true,
    "publishedAt": "2025-01-15T10:00:00Z",
    "viewCount": 150,
    "createdAt": "2025-01-15T10:00:00Z",
    "updatedAt": null,
    "category": {
      "id": 1,
      "name": "Technology",
      "slug": "technology"
    },
    "author": {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    },
    "tags": [
      {
        "id": 1,
        "name": "C#",
        "slug": "csharp"
      }
    ],
    "commentCount": 5
  }
]
```

### Get Post by Slug

```bash
curl -X GET "https://localhost:5001/api/posts/slug/getting-started-with-dotnet-9" \
     -H "accept: application/json"
```

### Create a New Post

```bash
curl -X POST "https://localhost:5001/api/posts" \
     -H "accept: application/json" \
     -H "Content-Type: application/json" \
     -d '{
       "title": "My First Blog Post",
       "content": "<p>This is the content of my first blog post.</p>",
       "excerpt": "A brief introduction to my first post",
       "featuredImage": "https://example.com/image.jpg",
       "isPublished": true,
       "categoryId": 1,
       "authorId": 1,
       "tagIds": [1, 2]
     }'
```

**Response:** `201 Created`
```json
{
  "id": 4,
  "title": "My First Blog Post",
  "slug": "my-first-blog-post",
  ...
}
```

### Update a Post

```bash
curl -X PUT "https://localhost:5001/api/posts/4" \
     -H "accept: application/json" \
     -H "Content-Type: application/json" \
     -d '{
       "title": "My Updated Blog Post",
       "content": "<p>Updated content.</p>",
       "excerpt": "Updated excerpt",
       "isPublished": true,
       "categoryId": 1,
       "authorId": 1,
       "tagIds": [1, 2]
     }'
```

**Response:** `204 No Content`

### Delete a Post

```bash
curl -X DELETE "https://localhost:5001/api/posts/4" \
     -H "accept: application/json"
```

**Response:** `204 No Content`

### Get Posts by Category

```bash
curl -X GET "https://localhost:5001/api/posts/category/1" \
     -H "accept: application/json"
```

### Get Posts by Tag

```bash
curl -X GET "https://localhost:5001/api/posts/tag/1" \
     -H "accept: application/json"
```

### Get Posts by Author

```bash
curl -X GET "https://localhost:5001/api/posts/author/1" \
     -H "accept: application/json"
```

## Categories

### Get All Categories

```bash
curl -X GET "https://localhost:5001/api/categories" \
     -H "accept: application/json"
```

### Create a Category

```bash
curl -X POST "https://localhost:5001/api/categories" \
     -H "accept: application/json" \
     -H "Content-Type: application/json" \
     -d '{
       "name": "DevOps",
       "description": "DevOps and CI/CD tutorials"
     }'
```

### Update a Category

```bash
curl -X PUT "https://localhost:5001/api/categories/1" \
     -H "accept: application/json" \
     -H "Content-Type: application/json" \
     -d '{
       "name": "Cloud Computing",
       "description": "Cloud platforms and services"
     }'
```

### Delete a Category

```bash
curl -X DELETE "https://localhost:5001/api/categories/1" \
     -H "accept: application/json"
```

## Comments

### Get Comments for a Post

```bash
curl -X GET "https://localhost:5001/api/comments/post/1" \
     -H "accept: application/json"
```

**Response:**
```json
[
  {
    "id": 1,
    "content": "Great article!",
    "authorName": "Reader One",
    "authorEmail": "reader1@example.com",
    "isApproved": true,
    "createdAt": "2025-01-16T10:00:00Z",
    "postId": 1,
    "parentCommentId": null,
    "replies": []
  }
]
```

### Create a Comment

```bash
curl -X POST "https://localhost:5001/api/comments" \
     -H "accept: application/json" \
     -H "Content-Type: application/json" \
     -d '{
       "content": "This is a great post!",
       "authorName": "John Doe",
       "authorEmail": "john@example.com",
       "postId": 1,
       "parentCommentId": null
     }'
```

### Reply to a Comment

```bash
curl -X POST "https://localhost:5001/api/comments" \
     -H "accept: application/json" \
     -H "Content-Type: application/json" \
     -d '{
       "content": "Thank you for your comment!",
       "authorName": "Author",
       "authorEmail": "author@example.com",
       "postId": 1,
       "parentCommentId": 1
     }'
```

### Approve a Comment

```bash
curl -X PUT "https://localhost:5001/api/comments/1/approve" \
     -H "accept: application/json"
```

**Response:** `204 No Content`

### Delete a Comment

```bash
curl -X DELETE "https://localhost:5001/api/comments/1" \
     -H "accept: application/json"
```

**Response:** `204 No Content`

## Using with Postman

1. Import the following collection URL: (to be created)
2. Set the base URL variable to `https://localhost:5001`
3. Run the requests

## Using with JavaScript/Fetch

```javascript
// Get all published posts
fetch('https://localhost:5001/api/posts/published')
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));

// Create a new post
fetch('https://localhost:5001/api/posts', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
  },
  body: JSON.stringify({
    title: 'My Post',
    content: '<p>Content here</p>',
    excerpt: 'Brief description',
    isPublished: true,
    categoryId: 1,
    authorId: 1,
    tagIds: [1]
  })
})
  .then(response => response.json())
  .then(data => console.log('Success:', data))
  .catch(error => console.error('Error:', error));
```

## Using with C#

```csharp
using System.Net.Http.Json;

var client = new HttpClient { BaseAddress = new Uri("https://localhost:5001") };

// Get published posts
var posts = await client.GetFromJsonAsync<List<PostDto>>("/api/posts/published");

// Create a new post
var newPost = new CreatePostDto
{
    Title = "My Post",
    Content = "<p>Content here</p>",
    Excerpt = "Brief description",
    IsPublished = true,
    CategoryId = 1,
    AuthorId = 1,
    TagIds = new List<int> { 1 }
};

var response = await client.PostAsJsonAsync("/api/posts", newPost);
var createdPost = await response.Content.ReadFromJsonAsync<PostDto>();
```

## Error Responses

### 400 Bad Request
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["The Title field is required."]
  }
}
```

### 404 Not Found
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
  "title": "Not Found",
  "status": 404
}
```

## Rate Limiting

Currently, there is no rate limiting implemented. This can be added in future versions.

## CORS

The API is configured to accept requests from any origin in development mode. For production, update the CORS policy in `Program.cs`.
