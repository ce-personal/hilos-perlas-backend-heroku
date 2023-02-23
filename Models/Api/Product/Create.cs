using System.ComponentModel.DataAnnotations;

namespace Nothing.Models.Api.Product
{
    public class ProductCreate
    {
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public decimal Price { get; set; }
        public decimal EquityPrice { get; set; }
        public int Quantity { get; set; }
        public bool UniquePiece { get; set; }
        public bool IsCustomProduct { get; set; }
    }
}
