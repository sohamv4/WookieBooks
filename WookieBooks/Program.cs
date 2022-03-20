using Microsoft.EntityFrameworkCore;
using WookieBooks;
using WookieBooks.BLL;
using WookieBooks.Models;
using WookieBooks.Repository;

var builder = WebApplication.CreateBuilder(args);

var options = new DbContextOptionsBuilder<BooksDbContext>()
   .UseInMemoryDatabase(databaseName: "Test")
   .Options;

using (var context = new BooksDbContext(options))
{
    var book = new Book
    {
        Author = "Elizabeth",
        Title = "Clean Code",
        Description = "23 Tsawassen.",
        CoverImage="Image",
        Price=50
    };

    context.Books.Add(book);
    context.SaveChanges();

}


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureApi();

app.Run();

