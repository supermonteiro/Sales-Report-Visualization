namespace Sales_Report_Visualization.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }

}
