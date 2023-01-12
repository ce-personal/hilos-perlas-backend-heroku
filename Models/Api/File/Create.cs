namespace Nothing.Models.Api.File
{
    public class FileCreate
    {
        public string? StringFile { get; set; }
        public bool IsItMainFile { get; set; }
        public Guid ProductId { get; set; }
    }
}
