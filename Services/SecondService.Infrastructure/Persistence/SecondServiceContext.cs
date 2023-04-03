using Microsoft.EntityFrameworkCore;
using SecondService.Domain.Entities;

namespace SecondService.Infrastructure.Persistence
{
    public class SecondServiceContext : DbContext
    {
        public SecondServiceContext(DbContextOptions<SecondServiceContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
