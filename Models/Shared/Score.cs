using Nothing.Models.Shop;

namespace Nothing.Models.Shared
{
    public class Score
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Value { get; set; }

        public Product? Product { get; set; }
    }
}
