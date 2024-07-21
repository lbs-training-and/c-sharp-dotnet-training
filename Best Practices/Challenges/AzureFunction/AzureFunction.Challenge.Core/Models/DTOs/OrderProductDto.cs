namespace AzureFunction.Challenge.Core.Models.DTOs
{
    public class OrderProductDto
    {
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public ProductDto Product { get; set; }

    }
}
