namespace Nothing.Models.Gen
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public Guid RecordId { get; set; }

        

        public UserAdmin? Record { get; set; }
    }
}
