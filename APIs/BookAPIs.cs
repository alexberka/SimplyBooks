using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;

namespace SimplyBooks.APIs
{
    public class BookAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/books", (SimplyBooksDbContext db, string Uid) =>
            {
                List<Book> userBooks = db.Books.Where(b => b.Uid == Uid).Include(b => b.Author).ToList();

                return userBooks.Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Image,
                    Author = new
                    {
                        b.Author.Id,
                        b.Author.FirstName,
                        b.Author.LastName
                    },
                    b.Price,
                    b.Sale
                })
                .OrderBy(b => b.Title);
            });

            app.MapGet("/books/{bookId}", (SimplyBooksDbContext db, int bookId, string Uid) =>
            {
                Book? thisBook = db.Books.Include(b => b.Author).SingleOrDefault(b => b.Id == bookId);

                if (thisBook == null)
                {
                    return Results.NotFound("Invalid Book Id");
                }
                if (thisBook.Uid != Uid)
                {
                    return Results.StatusCode(403);
                }

                return Results.Ok(new
                {
                    thisBook.Id,
                    thisBook.Title,
                    thisBook.Description,
                    thisBook.Image,
                    Author = new
                    {
                        thisBook.Author.Id,
                        thisBook.Author.FirstName,
                        thisBook.Author.LastName,
                        thisBook.Author.Image
                    },
                    thisBook.Price,
                    thisBook.Sale
                });
            });

            app.MapPost("/books", (SimplyBooksDbContext db, Book bookSubmit) =>
            {
                Author? authorLink = db.Authors.SingleOrDefault(a => a.Id == bookSubmit.AuthorId);

                if (authorLink == null || authorLink.Uid != bookSubmit.Uid)
                {
                    return Results.BadRequest("Invalid Author Id");
                }

                Book newBook = new()
                {
                    Title = bookSubmit.Title,
                    Image = bookSubmit.Image,
                    Description = bookSubmit.Description,
                    Price = bookSubmit.Price,
                    Sale = bookSubmit.Sale,
                    AuthorId = bookSubmit.AuthorId,
                    Uid = bookSubmit.Uid
                };

                db.Books.Add(newBook);
                db.SaveChanges();
                return Results.Created($"/books/{newBook.Id}", newBook);
            });

            app.MapPatch("/books/{bookId}", (SimplyBooksDbContext db, int bookId, Book bookSubmit) =>
            {
                Book? patchedBook = db.Books.FirstOrDefault(b => b.Id == bookId);

                if (patchedBook == null || bookSubmit.Id != bookId)
                {
                    return Results.NotFound("Invalid Book Id");
                }

                if (patchedBook.Uid != bookSubmit.Uid)
                {
                    return Results.StatusCode(403);
                }

                Author? authorLink = db.Authors.SingleOrDefault(a => a.Id == bookSubmit.AuthorId);

                if (authorLink == null || authorLink.Uid != bookSubmit.Uid)
                {
                    return Results.BadRequest("Invalid Author Id");
                }

                patchedBook.Title = bookSubmit.Title;
                patchedBook.Image = bookSubmit.Image;
                patchedBook.Description = bookSubmit.Description;
                patchedBook.Price = bookSubmit.Price;
                patchedBook.Sale = bookSubmit.Sale;
                patchedBook.AuthorId = bookSubmit.AuthorId;

                db.SaveChanges();
                return Results.Ok(patchedBook);
            });

            app.MapDelete("/books/{bookId}", (SimplyBooksDbContext db, int bookId, string Uid) =>
            {
                Book? deleteBook = db.Books.FirstOrDefault(b => b.Id == bookId);

                if (deleteBook == null)
                {
                    return Results.NotFound("Invalid Book Id");
                }

                if (deleteBook.Uid != Uid)
                {
                    return Results.StatusCode(403);
                }

                db.Books.Remove(deleteBook);
                db.SaveChanges();

                return Results.NoContent();
            });
        }
    }
}