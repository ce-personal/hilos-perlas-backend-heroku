namespace Nothing.Models.Api.Category
{
    public class CategoryPut
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
