using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Shop.Customizer;

namespace Nothing.Repositories
{
    public class CustomizerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomizerRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }


        public async Task<Part> GetPartByPartId(Guid partId)
        {
            var response = await _context.Part.Where(a => a.Id == partId).FirstOrDefaultAsync();
            return response;
        }

        public async Task<List<Part>> GetListPartByStep(StepPart stepPart)
        {
            var response = await _context.Part
                .Where(a => a.StepPart == stepPart)
                .ToListAsync();

            return response;
        }
    }
}
