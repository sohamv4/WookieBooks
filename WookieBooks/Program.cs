
//using WookieBooks;
using WookieBooks.Models;
using WookieBooks.Repository;

var builder = WebApplication.CreateBuilder(args);

//Two defaults inserts into in memory db
using (var context = new BooksDbContext())
{
    var book1 = new Book
        { 
        Author = "Elizabeth",
        Title = "Clean Code",
        Description = "23 Tsawassen.",
        CoverImage = "Image",
        Price = 50
        };
    var book2 = new Book
    {
        Author = "Tom",
        Title = "Apple",
        Description = "IPhone 13.",
        CoverImage = "Image",
        Price = 90
    };
    context.Books.Add(book1);
    context.Books.Add(book2);
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
WookieBooks.Api.ConfigureApi(app);

app.Run();

