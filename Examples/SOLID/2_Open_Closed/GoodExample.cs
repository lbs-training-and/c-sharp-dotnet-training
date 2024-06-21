// IPaymentMethod.cs
public interface IPaymentMethod
{
    void ProcessPayment();
}

// CreditCardPayment.cs
public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        // Process credit card payment
    }
}

// PayPalPayment.cs
public class PayPalPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        // Process PayPal payment
    }
}

// BitcoinPayment.cs
public class BitcoinPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        // Process Bitcoin payment
    }
}

// PaymentProcessor.cs
public class PaymentProcessor
{
    private readonly IPaymentMethod _paymentMethod;

    public PaymentProcessor(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void ProcessPayment()
    {
        _paymentMethod.ProcessPayment();
    }
}