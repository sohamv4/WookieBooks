
using System.ComponentModel.DataAnnotations;


namespace WookieBooks.Models
{
    public class Book:IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public short Price { get; set; }
    }
}
