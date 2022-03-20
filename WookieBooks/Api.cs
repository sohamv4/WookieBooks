using WookieBooks.BLL;
using WookieBooks.Models;
using WookieBooks.Repository;

namespace WookieBooks
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
              app.MapGet("/books", GetBooks);
            //app.MapGet("/todos", async (BooksLogic db) =>
            //{
            //    return  db.GetAll();
            //});
        }
        private static async Task<IResult> GetBooks()
        {
            try 
            {
                var bookRepo = new EFGenericRepository<Book>(null);
               
                return Results.Ok(bookRepo.GetAll());
            }
            catch(Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
    }
}
