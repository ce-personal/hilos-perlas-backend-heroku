using Nothing.Models;

namespace Nothing.Controllers
{
    public class CustomBaseController
    {
        public readonly ApplicationDbContext _context;

        public CustomBaseController(ApplicationDbContext context) 
        {
            _context = context;
        }   
    }
}
