using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CongratulatorContext : DbContext
    {
        public CongratulatorContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
