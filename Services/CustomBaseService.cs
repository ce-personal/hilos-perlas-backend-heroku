using Nothing.Models;

namespace Nothing.Services
{
    public class CustomBaseService
    {
        public readonly ApplicationDbContext _context;
        public CustomBaseService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}