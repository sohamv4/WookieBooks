using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using WookieBooks;
using WookieBooks.Models;
using WookieBooks.Repository;
using Xunit;

namespace WookieBooks.Tests
{
    public class BooksTests
    {
        [Fact]
        public async Task GetBooks()
        {
            await using var application = new WookieBookApplication();

            
            var client = application.CreateClient();
            var todos = await client.GetFromJsonAsync<List<Book>>("/books");

            Assert.NotEmpty(todos);
        }
        [Fact]
        public async Task PostBooks()
        {
            await using var application = new WookieBookApplication();

            var client = application.CreateClient();
            var book1 = new Book
            {
                Id=new System.Guid(),
                Author = "Elizabeth",
                Title = "Clean Code",
                Description = "23 Tsawassen.",
                CoverImage = "Image",
                Price = 50
            };
            var response = await client.PutAsJsonAsync("/books", new Book[] {book1});

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var todos = await client.GetFromJsonAsync<List<Book>>("/books");

            var todo = Assert.Single(todos);
            Assert.Equal("Abc", todo.Title);
        }
        class WookieBookApplication : WebApplicationFactory<Api>
        {
            protected override IHost CreateHost(IHostBuilder builder)
            {
                var root = new InMemoryDatabaseRoot();
              
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptionsBuilder));

                    services.AddDbContext<BooksDbContext>();
                    
                });
              
                return base.CreateHost(builder);
            }
        }
    }
}