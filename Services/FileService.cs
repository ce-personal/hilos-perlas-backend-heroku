using Nothing.Models;
using Nothing.Models.Api.File;

namespace Nothing.Services
{
    public class FileService : CustomBaseService 
    {
        public FileService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Models.Shared.File> Create(FileCreate file)
        {
            var model = new Models.Shared.File()
            {
                Date = DateTime.Now,
                IsItMainFile = file.IsItMainFile,
                ProductId = file.ProductId,
                StringFile = file.StringFile
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
