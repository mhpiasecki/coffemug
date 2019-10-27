using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMug.Models
{
    public class ProductCreateInputModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }

    }
}