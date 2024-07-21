using AzureFunction.Challenge.Core.Models.DTOs;

namespace AzureFunction.Challenge.Core.Models
{
    public class OrderDto
    {
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}
