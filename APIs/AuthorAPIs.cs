using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;

namespace SimplyBooks.APIs
{
    public class AuthorAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/authors", (SimplyBooksDbContext db, string Uid) =>
            {
                return Results.Ok(db.Authors.Where(a => a.Uid == Uid).Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName,
                    a.Image,
                    a.Email,
                    a.Favorite
                }));
            });

            app.MapGet("/authors/{authorId}", (SimplyBooksDbContext db, int authorId, string Uid) =>
            {
                Author? author = db.Authors.Include(a => a.Books).SingleOrDefault(a => a.Id == authorId);

                if (author == null)
                {
                    return Results.NotFound("Invalid Author Id");
                }

                if (author.Uid != Uid)
                {
                    return Results.StatusCode(403);
                }

                return Results.Ok(new
                {
                    author.Id,
                    author.FirstName,
                    author.LastName,
                    author.Email,
                    author.Image,
                    Books = author.Books.Select(b => new
                    {
                        b.Id,
                        b.Title,
                        b.Image,
                        b.Price,
                        b.Sale
                    }),
                    author.Favorite
                });
            });

            app.MapPost("/authors", (SimplyBooksDbContext db, Author submitAuthor) =>
            {
                Author newAuthor = new()
                {
                    FirstName = submitAuthor.FirstName,
                    LastName = submitAuthor.LastName,
                    Email = submitAuthor.Email,
                    Image = submitAuthor.Image,
                    Favorite = submitAuthor.Favorite,
                    Uid = submitAuthor.Uid
                };

                db.Authors.Add(newAuthor);
                db.SaveChanges();

                return Results.Created($"/authors/{newAuthor.Id}", newAuthor);
            });

            app.MapPatch("/authors/{authorId}", (SimplyBooksDbContext db, int authorId, Author submitAuthor) =>
            {
                Author? patchedAuthor = db.Authors.SingleOrDefault(a => a.Id == authorId);

                if (patchedAuthor == null || submitAuthor.Id != authorId)
                {
                    return Results.NotFound("Invalid Author Id");
                }

                if (patchedAuthor.Uid != submitAuthor.Uid)
                {
                    return Results.StatusCode(403);
                }

                patchedAuthor.FirstName = submitAuthor.FirstName;
                patchedAuthor.LastName = submitAuthor.LastName;
                patchedAuthor.Image = submitAuthor.Image;
                patchedAuthor.Email = submitAuthor.Email;
                patchedAuthor.Favorite = submitAuthor.Favorite;

                db.SaveChanges();

                return Results.Ok(patchedAuthor);
            });

            app.MapDelete("/authors/{authorId}", (SimplyBooksDbContext db, int authorId, string Uid) =>
            {
                Author? authorDelete = db.Authors.SingleOrDefault(a => a.Id == authorId);

                if (authorDelete == null)
                {
                    return Results.NotFound("Invalid Author Id");
                }

                if (authorDelete.Uid != Uid)
                {
                    return Results.StatusCode(403);
                }

                db.Authors.Remove(authorDelete);
                db.SaveChanges();

                return Results.NoContent();
            });

        }
    }
}