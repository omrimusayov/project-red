using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using project_red.Models;

namespace Project_RED.Models {
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<student> students { get; set; } = null!;
    }
}
