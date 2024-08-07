namespace AzureFunction.Challenge.Function.Core.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
