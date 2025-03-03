using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        

        public string? ProductName { get; set; } = string.Empty;
        
        
        public decimal Price { get; set; }

        //FK
        public int? CategoryId { get; set; }

        //Navigation
        public Category? Category { get; set; }
    }
}
