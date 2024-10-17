using Microsoft.EntityFrameworkCore;
using RectangleAssignment.Domain;

namespace RectangleAssignment.Infrastructure
{
    public class RectangleDbContext(DbContextOptions<RectangleDbContext> opt) 
        : DbContext(opt)
    {

        public DbSet<RectangleDimension> RectangleDimensions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RectangleDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
