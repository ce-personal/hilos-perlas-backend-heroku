using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.File;
using Nothing.Services;

namespace Nothing.Controllers
{
    [ApiController]
    public class FileController : CustomBaseController
    {
        private readonly FileService _fileService;
        public FileController(ApplicationDbContext context): base(context)
        {
            _fileService = new FileService(context);
        }

        [HttpPost, Route("/File/Create")]
        public async Task<Models.Shared.File> Create([FromForm]FileCreate file)
        {
            var response = await _fileService.Create(file);
            return response;
        }
    }
}
