using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WookieBooks.Models;

namespace WookieBooks.Repository
{
    public class BooksDbContext:DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }
        public DbSet<Book> Books => Set<Book>();
    }
}
