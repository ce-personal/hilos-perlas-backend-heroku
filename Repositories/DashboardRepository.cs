using Nothing.Models;

namespace Nothing.Repositories
{
    public class DashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
