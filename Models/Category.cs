namespace Sales_Report_Visualization.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        // Other properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
