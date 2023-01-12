using Microsoft.EntityFrameworkCore;
using Nothing.Models.Gen;
using Nothing.Models.Shared;
using Nothing.Models.Shop;

namespace Nothing.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public DbSet<Client> Client { get; set; }
        public DbSet<UserAdmin> UserAdmin { get; set; }
        public DbSet<Category> Category { get; set; }
        
        public DbSet<Product> Product { get; set; }
        public DbSet<CustomProduct> CustomProduct { get; set; }
        public DbSet<Level> FirstLevel { get; set; }
        public DbSet<Level> SecondLevel { get; set; }
        public DbSet<Level> ThirdLevel { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<ItemOrder> ItemOrder { get; set; }


        public DbSet<Score> Score { get; set; }
        public DbSet<Shared.File> File { get; set; }
    }
}
