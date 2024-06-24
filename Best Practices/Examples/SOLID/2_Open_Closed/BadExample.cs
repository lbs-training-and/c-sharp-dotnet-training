// PaymentProcessor.cs
public class PaymentProcessor
{
    public void ProcessPayment(string paymentType)
    {
        if (paymentType == "CreditCard")
        {
            // Process credit card payment
        }
        else if (paymentType == "PayPal")
        {
            // Process PayPal payment
        }
        else if (paymentType == "Bitcoin")
        {
            // Process Bitcoin payment
        }
    }
}