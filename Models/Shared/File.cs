using Nothing.Models.Gen;
using Nothing.Models.Shop;

namespace Nothing.Models.Shared
{
    public class File
    {
        public Guid Id { get; set; }
        public string? StringFile { get; set; }
        public DateTime Date { get; set; }
        public Guid? RecordId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? UserAdminId { get; set; }
        public bool IsItMainFile { get; set; }


        public UserAdmin? Record { get; set; }
        public Product? Product { get; set; }
        public UserAdmin? UserAdmin { get; set; }
        public Guid? PartId { get; set; }
    }
}
