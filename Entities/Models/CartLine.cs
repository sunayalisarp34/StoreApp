namespace Entities.Models
{
    public class CartLine
    {
        public int CatrLineId { get; set; }
        public Product Product { get; set; } = new();

        public int Quantity { get; set; }
    }
}
