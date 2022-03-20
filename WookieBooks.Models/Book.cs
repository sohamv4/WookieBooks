using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WookieBooks.Models
{
    public class Book:IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public short Price { get; set; }
    }
}
