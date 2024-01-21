using Microsoft.EntityFrameworkCore;
using versta24.Models;

namespace versta24.Data
{
    public class VerstaDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryAddress> Addresses { get; set; }

        public VerstaDbContext(DbContextOptions<VerstaDbContext> context) : base(context) 
        {
            Database.EnsureCreated();
        }
    }
}
