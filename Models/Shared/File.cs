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
        public Guid? FirstLevelId { get; set; }
        public Guid? SecondLevelId { get; set; }
        public Guid? ThirdLevelId { get; set; }
        public bool IsItMainFile { get; set; }


        public UserAdmin? Record { get; set; }
        public Product? Product { get; set; }
        public Level? FirstLevel { get; set; }
        public Level? SecondLevel { get; set; }
        public Level? ThirdLevel { get; set; }
    }
}
