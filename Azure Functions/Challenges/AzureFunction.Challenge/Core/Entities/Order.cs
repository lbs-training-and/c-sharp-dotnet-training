using AzureFunction.Challenge.Function.Core.Models;

namespace AzureFunction.Challenge.Function.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}