using System;
using System.ComponentModel.DataAnnotations;

namespace BookstoreApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
