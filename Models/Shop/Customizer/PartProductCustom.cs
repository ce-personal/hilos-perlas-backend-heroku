using Nothing.Models.Gen;

namespace Nothing.Models.Shop.Customizer
{
    public class PartProductCustom
    {
        public Guid Id { get; set; }
        public Guid PartId { get; set; }
        public Guid ProductCustomId { get; set; }
        public Guid ClientId { get; set; }

        public Part Part { get; set; }
        public ProductCustom ProductCustom { get; set; }
        public Client Client { get; set; }
    }
}
