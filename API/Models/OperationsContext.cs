using Microsoft.EntityFrameworkCore;
namespace API.Models
{
    public class OperationsContext : DbContext
    {
        public OperationsContext(DbContextOptions<OperationsContext>options):base(options)
        {
        }
        public DbSet<Operations>Operations{get;set;}
    }
}