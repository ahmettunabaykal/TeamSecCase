This file contains json format http requests to ease testing process.
Writers operations: 

Dockerfile'da bulunan localhost portuna göre yazılmıştır.

POST
http://localhost:8080/writers
{
    "Name": "Ahmet Baykal",
    "Bio": "An enthusiastic writer"
}

GET
http://localhost:8080/writers 
Bütün writerlar için.

GET
http://localhost:8080/writers/id
Spesific writerlar için

PUT

DELETE
http://localhost:8080/writers/id

Article Operations:

POST
http://localhost:8080/articles
{
    "Title": "The Evolution of Machine Intelligence",
    "Content": "This article explores the journey of artificial intelligence from its inception to the current state...",
    "PublishedDate": "2024-03-19T00:00:00",
    "AddedDate": "2024-03-19T00:00:00", // This might be automatically set by your backend
    "WriterId": 1,
    "CategoryId": 2,
    "Tags": ["AI", "Machine Learning", "History"]
}

GET
http://localhost:8080/articles 
Bütün Article'lar için

GET
http://localhost:8080/articles/id
Spesifik Article'lar için

PUT
http://localhost:8080/articles/id
{.  "Id": 1,
    "Title": "Updated Article Title",
    "Content": "This is the updated content of the article.",
    "PublishedDate": "2024-03-20T00:00:00",
    "AddedDate": "2024-03-19T00:00:00",
    "WriterId": 1,
    "CategoryId": 2,
    "Tags": ["Updated", "Article", "Tags"]
}
İçerdeki Id ile url'deki id aynı olmak zorunda. 

DELETE 
http://localhost:8080/articles/id
{"Id": 1,
    "Title": "Updated Article Title",
    "Content": "This is the updated content of the article.",
    "PublishedDate": "2024-03-20T00:00:00",
    "AddedDate": "2024-03-19T00:00:00",
    "WriterId": 2,
    "CategoryId": 2,
    "Tags": ["Updated", "Article", "Tags"]
}
İçerdeki Id ile url'deki id aynı olmak zorunda. 

GET
http://localhost:8080/articles/articles/latest-published

GET
http://localhost:8080/articles/articles/oldest-published

GET
http://localhost:8080/articles/articles/latest-added

GET
http://localhost:8080/articles/articles/oldest-published

GET
http://localhost:8080/articles/articles/by-category/{categoryId}

GET
http://localhost:8080/articles/articles/by-tag/{tagName}

POST
http://localhost:8080/articles/id/like   
Like eklenir belirtilen id'li article'a

POST
http://localhost:8080/articles/id/rate
Body'de sadece double bulunur
4.3

POST
http://localhost:8080/comments/
{
  "Content": "This is a sample comment.",
  "ArticleId": 1,
  "WriterId": 1 // Assuming the writer's ID is known
}

GET
http://localhost:8080/comments/
Bütün commentleri döndürür

GET
http://localhost:8080/comments/id
Belirtilen id'li commentleri döndürür.

PUT
http://localhost:8080/comments/id
{
  "Id": 1, // This ID should match the ID in the URL
  "Content": "This is the updated comment content.",
  "ArticleId": 1 // Assuming the comment belongs to the first article
}
We need to provide the exact WriterId of the comment owner to Header. 
Such as : Key - > WriterId , Value -> 1

DELETE
http://localhost:8080/comments/id
No body is needed, just the right WriterId should be sent via header.

