using Nothing.Models.Shop.Customizer;

namespace Nothing.Models.Api.Customizer
{
    public class PostCreateNewPart
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public StepPart StepPart { get; set; }

    }
}
