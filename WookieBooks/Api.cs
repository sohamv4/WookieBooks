using Microsoft.AspNetCore.Mvc;

using WookieBooks.BLL;
using WookieBooks.Models;
using WookieBooks.Repository;

namespace WookieBooks
{
    public class Api
    {
        public static void ConfigureApi(WebApplication app)
        {
            app.MapGet("/books", GetBooks)
                .Produces<List<Book>>(StatusCodes.Status200OK)
                .WithName("GetBooks").WithTags("Getters"); 
            app.MapPost("/books", PostBooks)
                .Accepts<Book[]>("application/json")
                .Produces<Book[]>(StatusCodes.Status201Created)
                .WithName("AddNewBook").WithTags("Setters");
            app.MapPut("/books", UpdateBooks)
                .Accepts<Book[]>("application/json")
                .Produces<Book[]>(StatusCodes.Status201Created).Produces(StatusCodes.Status404NotFound)
                .WithName("UpdateBook").WithTags("Setters");
            app.MapDelete("/books", DeleteBooks)
                .Accepts<Book[]>("application/json")
                .Produces(StatusCodes.Status202Accepted).Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteBook").WithTags("Setters");
        }
        private static  async Task<IResult> GetBooks()
        {
            try
            {
                var bookRepo = new EFGenericRepository<Book>();
                var logic = new BooksLogic(bookRepo);

                return Results.Ok(logic.GetAll());
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static async Task<IResult> PostBooks(Book[] addbooks)
        {
            try
            {
                if (addbooks.Count() == 0)
                    return Results.BadRequest();

                var bookRepo = new EFGenericRepository<Book>();
                var logic = new BooksLogic(bookRepo);

                logic.Add(addbooks);
                return Results.Created($@"/books", addbooks);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static async Task<IResult> UpdateBooks(Book[] updatebooks)
        {
            try
            {
                if (GetId(updatebooks) == Guid.Empty)
                    return Results.BadRequest();

                var bookRepo = new EFGenericRepository<Book>();
                var logic = new BooksLogic(bookRepo);

                logic.Update(updatebooks);
                return Results.Created("books", updatebooks);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static async Task<IResult> DeleteBooks([FromBody] Book[] books)
        {
            try
            {
                if (GetId(books) == Guid.Empty)
                    return Results.BadRequest();

                var bookRepo = new EFGenericRepository<Book>();
                var logic = new BooksLogic(bookRepo);

                logic.Delete(books);
                return Results.Accepted();
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static Guid GetId(Book[] books)
        {
            var book = new Book();
            var bookRepo = new EFGenericRepository<Book>();
            var logic = new BooksLogic(bookRepo);
            foreach (var item in books)
            {
                book = logic.Get(item.Id);
            }
            return book.Id;
        }
    }
}
