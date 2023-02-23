using Nothing.Models.Gen;

namespace Nothing.Models.Shop
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal EquityPrice { get; set; }
        public int Quantity { get; set; }
        public bool UniquePiece { get; set; }
        public Guid? RecordId { get; set; }
        public DateTime Date { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ProductCustoId { get; set; }


        public UserAdmin? Record { get; set; }
        public Category? Category { get; set; }
        public ProductCustom? ProductCustom { get; set; }
    }
}
