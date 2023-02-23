using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Customizer;
using Nothing.Models.Api.File;
using Nothing.Models.Shop;
using Nothing.Models.Shop.Customizer;
using Nothing.Services;

namespace Nothing.Controllers
{
    public class PartController : CustomBaseController
    {
        private readonly CustomizerService _customizerService;
        private readonly FileService _fileService;
        public PartController(ApplicationDbContext context): base(context)
        { 
            _customizerService = new CustomizerService(context);
            _fileService = new FileService(context);
        }


        [HttpPost, Route("/Part/PostCreateNewPart")]
        public async Task<Part> PostCreateNewPart(PostCreateNewPart newPart)
        {
            var response = await _customizerService.PostCreateNewPart(newPart);
            return response;
        }

        [HttpPost, Route("/Part/PostUploadFileByPart")]
        public async Task PostUploadFileByPart(Guid partId, bool isMain, string fileString)
        {
            var modelFile = new FileCreate()
            {
                IsItMainFile = isMain,
                PartId = partId,
                StringFile = fileString
            };

            var file = await _fileService.Create(modelFile);
            await _customizerService.UpdatePartByFile(partId, isMain, file.Id);
        }

        [HttpGet, Route("/Part/GetListPartByStep")]
        public async Task<List<Part>> GetListPartByStep(StepPart stepPart)
        {
            var response = await _customizerService.GetListPartByStep(stepPart);
            return response;
        }


        [HttpDelete, Route("/Part/DeletePartByPartId")]
        public async Task<bool> DeletePartByPartId(Guid partId)
        {
            var response = await _customizerService.DeletePartByPartId(partId);
            return response;
        }

        [HttpPost, Route("/Part/PostSaveProductCustomByPart")]
        public async Task PostSaveProductCustomByPart(Guid part0, Guid part1, Guid part2, Guid clientId)
        {
            var model = new ProductCustom()
            { 
                Date = DateTime.Now,
                Estado = true,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            var modelPart0 = new PartProductCustom()
            {
                PartId = part0,
                ProductCustomId = model.Id,
                ClientId = clientId
            };

            if (part1 != Guid.Empty)
            {
                var modelPart1 = new PartProductCustom()
                {
                    PartId = part1,
                    ProductCustomId = model.Id,
                    ClientId = clientId
                };

                await _context.AddAsync(modelPart1);
            }

            if (part2 != Guid.Empty)
            {
                var modelPart2 = new PartProductCustom()
                {
                    PartId = part2,
                    ProductCustomId = model.Id,
                    ClientId = clientId
                };

                await _context.AddAsync(modelPart2);
            }




            await _context.AddAsync(modelPart0);
            await _context.SaveChangesAsync();
        }
    }
}
