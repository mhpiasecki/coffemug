using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMug.Models
{
    public class ProductUpdateInputModel
    {
        [Required]        
        public Guid? Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}