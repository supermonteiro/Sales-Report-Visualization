using Microsoft.EntityFrameworkCore;
using Sales_Report_Visualization.Data;
using Sales_Report_Visualization.Models;

namespace MyProject.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Check if the database is already seeded
            if (context.Categories.Any())
            {
                return; // Database has already been seeded
            }

            // Add sample data
            var categories = new[]
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Clothing" },
                // Add more categories as needed
            };
            context.Categories.AddRange(categories);

            // Add sample products
            var products = new[]
            {
                new Product { Name = "Smartphone", CategoryId = 1 },
                new Product { Name = "Laptop", CategoryId = 1 },
                // Add more products as needed
            };
            context.Products.AddRange(products);

            // Add sample brands and associate them with products
            var brands = new[]
            {
                new Brand { Name = "Samsung" },
                new Brand { Name = "Apple" },
                // Add more brands as needed
            };
            context.Brands.AddRange(brands);

            // Associate brands with products
            brands[0].Products.Add(products[0]); // Samsung associated with Smartphone
            brands[1].Products.Add(products[0]); // Apple associated with Smartphone

            // Add sample sales data (adjust as needed)
            var salesData = new[]
            {
                new SalesData { Month = new DateTime(2023, 1, 1), Brand = brands[0], QuantitySold = 100 },
                new SalesData { Month = new DateTime(2023, 1, 1), Brand = brands[1], QuantitySold = 120 },
                // Add more sales data as needed with appropriate DateTime values
            };
            context.SalesDatas.AddRange(salesData);

            context.SaveChanges();
        }
    }
}