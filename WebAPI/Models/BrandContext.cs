using Microsoft.EntityFrameworkCore;
namespace CrudOperations.models
#nullable disable
{
    public class BrandContext: DbContext
    {
        public BrandContext(DbContextOptions<BrandContext>options):base(options)
        {            
        }
        public DbSet<Brand> Brands{get;set;}
    }
}