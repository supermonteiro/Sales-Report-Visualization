using Microsoft.EntityFrameworkCore;
using Sales_Report_Visualization.Data;
using Sales_Report_Visualization.Models;

namespace Sales_Report_Visualization.Services
{
    public class DashboardService
    {
        private readonly ApplicationDbContext _dbContext; // Your database context

        public DashboardService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public List<Product> GetProducts(int categoryId)
        {
            return _dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public List<Brand> GetBrands(int categoryId, int productId)
        {
            return _dbContext.Brands
                .Where(b => b.Products.Any(p => p.ProductId == productId && p.CategoryId == categoryId))
                .ToList();
        }

        public IEnumerable<SalesData> GetSalesData(int categoryId, int productId, int brandId)
        {
            // Get the current year
            int currentYear = DateTime.Now.Year;

            // Calculate the start and end dates for the first four months of the current year
            DateTime startDate = new DateTime(currentYear, 1, 1); // January 1st
            DateTime endDate = new DateTime(currentYear, 4, 30); // April 30th

            // Query the database to retrieve sales data for the specified filters
            var query = _dbContext.SalesDatas
                .Where(s =>
                    s.Month >= startDate &&
                    s.Month <= endDate);

            if (categoryId > 0)
            {
                query = query.Where(s => s.Product.CategoryId == categoryId);
            }

            if (productId > 0)
            {
                query = query.Where(s => s.ProductId == productId);
            }

            if (brandId > 0)
            {
                query = query.Where(s => s.BrandId == brandId);
            }

            // Group and aggregate data by month
            var result = query
                .GroupBy(s => s.Month.Month)
                .Select(group => new SalesData
                {
                    Month = new DateTime(currentYear, group.Key, 1),
                    TotalSales = group.Sum(s => s.QuantitySold)
                })
                .ToList();

            return result ?? Enumerable.Empty<SalesData>();
        }
    }

}
