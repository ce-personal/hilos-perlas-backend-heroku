using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Shared;
using System.Linq;

namespace Nothing.Repositories
{
    public class FileRepository
    {
        private readonly ApplicationDbContext _context;
        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Nothing.Models.Shared.File>> GetListFileByProductIds(List<Guid?> productIds)
        {
            if (productIds == null) return new List<Nothing.Models.Shared.File>();

            var response = await _context.File
                .Where(a => a.ProductId != null)
                .Where(a => productIds.Contains((Guid)a.ProductId))
                .ToListAsync();

            return response;
        }


        public async Task<List<Nothing.Models.Shared.File>> GetListFileByProductIds(List<Guid> productIds)
        {
            if (productIds == null) return new List<Nothing.Models.Shared.File>();

            var response = await _context.File
                .Where(a => a.ProductId != null)
                .Where(a => productIds.Contains((Guid)a.ProductId))
                .ToListAsync();

            return response;
        }


        public async Task<List<Nothing.Models.Shared.File>> GetListFileByProductId(Guid productId)
        {
            var response = await _context.File
               .Where(a => a.ProductId == productId)
               .ToListAsync();

            return response;
        }

        public async Task<List<Nothing.Models.Shared.File>> GetListFileByUserAdminId(Guid userAdminId)
        {
            var response = await _context.File
               .Where(a => a.UserAdminId == userAdminId)
               .ToListAsync();

            return response;
        }

        public async Task<Nothing.Models.Shared.File> GetFileByUserAdminId(Guid userAdminId)
        {
            var response = await _context.File
               .Where(a => a.UserAdminId == userAdminId)
               .FirstOrDefaultAsync();

            return response;
        }


        public async Task<List<Nothing.Models.Shared.File>> GetFileByPart(Guid partId)
        {
            var response = await _context.File.Where(a => a.PartId == partId).ToListAsync();
            return response;
        }

        public async Task<List<Nothing.Models.Shared.File>> GetListFileByPartId(List<Guid> listPartId)
        {
            var response = await _context.File.Where(a => listPartId.Contains((Guid)a.PartId)).ToListAsync();
            return response;
        }
    }
}
