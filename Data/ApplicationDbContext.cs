using Microsoft.EntityFrameworkCore;
using Sales_Report_Visualization.Models;

namespace Sales_Report_Visualization.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet properties for your entity classes
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesData> SalesDatas { get; set; }
    }
}
