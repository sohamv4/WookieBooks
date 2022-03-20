using Microsoft.EntityFrameworkCore;

using WookieBooks.Models;

namespace WookieBooks.Repository
{
    public class BooksDbContext:DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //pass db config on the optionsBuilder
            optionsBuilder.UseInMemoryDatabase(databaseName: "Test");

            base.OnConfiguring(optionsBuilder);
           
        }
       

    }
}
