namespace Nothing.Models.Shop
{
    public class ItemOrder
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ProductCustomId { get; set; }
        public int Quantity { get; set; }


        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public ProductCustom? ProductCustom { get; set; }
    }
}
