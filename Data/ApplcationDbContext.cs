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
    }
}
