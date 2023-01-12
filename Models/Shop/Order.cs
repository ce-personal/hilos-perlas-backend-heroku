using Nothing.Models.Gen;

namespace Nothing.Models.Shop
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime Date { get; set; }
        public string? Ubication { get; set; }
        public DateTime DeliveryDate { get; set; }
        public StatusOrder Status { get; set; }

        public Client? Client { get; set; }
    }

    public enum StatusOrder 
    {
        Solicitado,
        Recibido,
        EnProduccion,
        Terminado,
        Entregado
    }
}
