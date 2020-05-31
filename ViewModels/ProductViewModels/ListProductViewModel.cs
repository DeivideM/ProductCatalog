namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class ListProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
