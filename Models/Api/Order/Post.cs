namespace Nothing.Models.Api.Order
{
    public class OrderPost
    {
        public Guid ClientId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? Ubication { get; set; }
    }

    public class ItemOrderPost
    {
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
