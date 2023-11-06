using Microsoft.EntityFrameworkCore;
using MovieManagement.Model;

namespace MovieManagement.Data
{
    public class ApplcationDbContext : DbContext
    {
        public ApplcationDbContext(DbContextOptions<ApplcationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenres"));
        }

    }
}
