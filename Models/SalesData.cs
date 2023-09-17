namespace Sales_Report_Visualization.Models
{
    public class SalesData
    {
        internal object TotalSales;

        public int SalesDataId { get; set; }
        public DateTime Month { get; set; }        
        public DateTime Year { get; set; }        
        public int QuantitySold { get; set; }

        // Foreign keys
        public int ProductId { get; set; }
        public int BrandId { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public Brand Brand { get; set; }
    }
}
