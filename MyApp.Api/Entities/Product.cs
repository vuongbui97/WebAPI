using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Entities
{
    public class Product : EntityBase
    {
        public Product(string name, string? description, decimal? price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }
        
        [Key]
        public string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public decimal? Price { get; set; } = decimal.Zero;

    }
}