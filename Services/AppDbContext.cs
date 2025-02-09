using Microsoft.EntityFrameworkCore;
using Task = auto_tasker.Models.Task;

namespace auto_tasker.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}
