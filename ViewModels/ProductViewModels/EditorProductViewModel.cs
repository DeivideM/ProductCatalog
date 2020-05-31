
namespace ProductCatalog.ViewModels.ProductViewModels
{
    /// <summary>
    /// Used to Create and Edit
    /// </summary>
    public class EditorProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
