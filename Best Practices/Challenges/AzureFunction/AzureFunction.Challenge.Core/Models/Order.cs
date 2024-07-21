namespace AzureFunction.Challenge.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}