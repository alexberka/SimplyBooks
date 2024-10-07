
<h1 align="center" style="font-weight: bold;">SimplyBooks</h1>

<p align="center">
<a href="#tech">Technologies</a>
<a href="#started">Getting Started</a>
<a href="#routes">API Endpoints</a>
</p>


<p>SimplyBooks is an author/book database and API with user-specific data management. It utilizes postgres and EF Core to create and manage a local database.</p>


<h2 id="technologies">Technologies</h2>

- C#/.Net
- Entity Framework Core
- Visual Studio
- postgres/pgAdmin
- Swagger (development only)

<h2>User-Specific Data</h2>

Data in SimplyBooks is user-specific, to the extent that all data must be associated with a user via uid. Only users with that uid can access/edit that data. For many calls, the uid is passed as a query parameter to verify permissions. For the remainder, it is include in the request body. The uid may be handled by any authnetication process integrated into the UI (Google Firebase, etc.) or may be manually specified by the user when creating the data. Once the data is created, the associated uid cannot be altered.

<h2 id="started">Getting Started</h2>

Clone this project to a directory on your machine using

```bash
git clone git@github.com:alexberka/SimplyBooks.git
```

Open the solution file in Visual Studio. In order to initialize the database on your machine and populate with seed data, run:

```
ef database update
```

in the terminal.

<h2>Data Structures</h2>
Data is stored as either an Author entity:

```
{
  Id: <int>,
  FirstName: <string>,
  LastName: <string>,
  Email: <string>,
  Image: <string>,
  Uid: <string>,
  Favorite: <boolean>,
  Books: [List<Book>],
}
```

or as a Book entity:

```
{
  Id: <int>,
  Title: <string>,
  Description: <string>,
  Image: <string>,
  AuthorId: <int>,
  Author: <Author>
  Uid: <string>,
  Price: <decimal>,
  Sale: <boolean>
}
```

All Books must be associated upon creation with an Author via the AuthorId property. A Book and its corresponding Author must belong to the same user (have the same uid).

<h2>Running the Application</h2>

The application can be started in the terminal is Visual Studio using:

```
dotnet run
```

or started in the debugger. If started with the debugger, the app will enter development mode, and Swagger will automatically open in a new window.

To interact with the API via Postman, access the [SimplyBooks Documentation on Postman](https://documenter.getpostman.com/view/31791227/2sAXxP9XzJ) and click "Run in Postman". Choose either the web or desktop app in the popup, select a collection to import into, and click import.

The {{baseUrl}} variable must be adjusted to the proper local port. Find this in your Visual Studio terminal or in the Swagger window if operating in development mode.

<h2 id="routes">API Endpoints</h2>

Here is a list of all endpoints and their functions.
For complete endpoint documentation, visit [SimplyBooks Documentation on Postman](https://documenter.getpostman.com/view/31791227/2sAXxP9XzJ)
​
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /authors?uid=\<uid\></kbd>     | retrieve user's authors
| <kbd>POST /authors</kbd>     | create author
| <kbd>GET /authors/{authorId}?uid=\<uid\></kbd>     | retrieve single author with books
| <kbd>PATCH /authors/{authorId}</kbd>     | update author
| <kbd>DELETE /authors/{authorId}?uid=\<uid\></kbd>     | delete author
| <kbd>GET /authors/favorite?uid=\<uid\></kbd>     | retrieve user's favorited authors
| <kbd>PATCH /authors/favorite/{authorId}?uid=\<uid\></kbd>     | toggle author's "favorite" status
| <kbd>GET /books?uid=\<uid\></kbd>     | retrieve user's books
| <kbd>POST /books</kbd>     | create book
| <kbd>GET /books/{bookId}?uid=\<uid\></kbd>     | retrieve single book
| <kbd>PATCH /books/{bookId}</kbd>     | update book
| <kbd>DELETE /books/{bookId}?uid=\<uid\></kbd>     | delete book

<h3>Further Documentation</h3>

[Operational Walk-Through on Loom](https://www.loom.com/share/56fefb5906a44ba3b5d1ec7da7411569)
