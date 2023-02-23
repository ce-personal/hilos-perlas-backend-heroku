using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Customizer;
using Nothing.Models.Shop.Customizer;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class CustomizerService: CustomBaseService
    {
        private readonly CustomizerRepository _customizerRepo;
        private readonly FileRepository _fileRepo;
        public CustomizerService(ApplicationDbContext context) : base(context) 
        { 
            _customizerRepo = new CustomizerRepository(context);
            _fileRepo = new FileRepository(context);
        }


        public async Task<Part> PostCreateNewPart(PostCreateNewPart newPart)
        {
            var model = new Part()
            {
                Description = newPart.Description,
                Name = newPart.Name,
                Price = newPart.Price,
                StepPart = newPart.StepPart,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task UpdatePartByFile(Guid partId, bool isMain, Guid fileId)
        {
            var part = await _customizerRepo.GetPartByPartId(partId);
            if (isMain)
            {
                part.FileMainId = fileId;
            }

            else
            {
                part.FileSecondaryId = fileId;
            }


            _context.Update(part);
            await _context.SaveChangesAsync();
        }



        public async Task<List<Part>> GetListPartByStep(StepPart stepPart)
        {
            var response = await _customizerRepo.GetListPartByStep(stepPart);
            
            var listPartId = response.Select(a => a.Id).ToList();
            var listFile = await _fileRepo.GetListFileByPartId(listPartId);

            foreach (var item in response)
            {
                var fileMain = listFile.Where(a => a.Id == item.FileMainId).First();
                var fileSecondary = listFile.Where(a => a.Id == item.FileSecondaryId).First();


                item.FileMain = fileMain;
                item.FileSecondary = fileSecondary;
            }

            return response;
        }


        public async Task<bool> DeletePartByPartId(Guid partId)
        {
            try
            {
                var part = await _customizerRepo.GetPartByPartId(partId);
                var fileByPart = await _fileRepo.GetFileByPart(partId);

                _context.Remove(part);
                _context.RemoveRange(fileByPart);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
