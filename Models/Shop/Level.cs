using Nothing.Models.Gen;

namespace Nothing.Models.Shop
{
    public class Level
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }


        public Category? Category { get; set; }
    }
}
