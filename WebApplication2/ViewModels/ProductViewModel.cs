namespace WebApplication2.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public string Category { get; set; }
        public int NewPrice { get
            { return Price - (Price / 100) * Discount.GetValueOrDefault(); } }
    }
}
