namespace AzureFunction.Challenge.Function.Core.Models.DTOs
{
    public class OrderDto
    {
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}
