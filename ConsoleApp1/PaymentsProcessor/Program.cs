namespace PaymentsProcessor;

class Program
{
    static void Main(string[] args)
    {
        // Which payment processor to use ?
        decimal amount = 100.00m;
        string currency = "EUR";

        IPaymentProcessor paymentProcessor = PaymentProcessorFactory.GetPaymentProcessor(args[0]);

        // IPaymentDetails paymentDetails = PaymentDetailsFactory.GetPaymentDetails(customerId, args[0], amount, currency);

        IPaymentDetails paymentDetails = GetPaymentDetails(paymentProcessor, amount, currency);

        // TODO: We need to return the TransactionId from the Charge method
        PaymentStatus status = paymentProcessor.Charge(paymentDetails);
        Console.WriteLine($"Payment processed successfully for type: {paymentProcessor.GetType().Name}.");

        paymentProcessor = PaymentProcessorFactory.GetPaymentProcessor("PayPal");
        paymentDetails = GetPaymentDetails(paymentProcessor, amount, currency);

        status = paymentProcessor.Charge(paymentDetails);

        Console.WriteLine($"Payment processed successfully for type: {paymentProcessor.GetType().Name}.");
    }

    public static IPaymentDetails GetPaymentDetails(IPaymentProcessor paymentProcessor, decimal amount, string currency)
    {
        IPaymentDetails paymentDetails = null;
        if (paymentProcessor is BankTransferProcessor)
        {
            paymentDetails = new BankPaymentDetails
            {
                Amount = amount,
                Currency = currency,
                IBAN = "DE89370400440532013000"
            };
        }

        if (paymentProcessor is CreditCardProcessor)
        {
            paymentDetails = new CreditCardPaymentDetails
            {
                Amount = amount,
                Currency = currency,
                CardNumber = "1234-5678-9012-3456",
                ExpiryDate = DateTime.Now.AddYears(2)
            };
        }

        if (paymentProcessor is PaypalProcessor)
        {
            paymentDetails = new PaypalPaymentDetails
            {
                Amount = amount,
                Currency = currency,
                Email = "test@test.com"
            };
        }

        return paymentDetails;
    }
}

public class PaypalPaymentDetails : IPaymentDetails
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Email { get; set; }
}

public class CreditCardPaymentDetails : IPaymentDetails
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
}

public class BankPaymentDetails : IPaymentDetails
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string IBAN { get; set; }
}

public class PaypalProcessor : IPaymentProcessor
{
    public PaymentStatus Charge(IPaymentDetails paymentDetails)
        //(string email, decimal amount, string currency)
    {
        PaypalPaymentDetails paypalPaymentDetails = paymentDetails as PaypalPaymentDetails;

        if (paypalPaymentDetails == null)
        {
            throw new ArgumentException("Invalid payment details for PayPal processor.");
        }

        // Simulate payment processing
        Console.WriteLine(
            $"Processing payment of {paypalPaymentDetails.Amount:C}{paypalPaymentDetails.Currency} for PayPal account {paypalPaymentDetails.Email}.");
        // Here you would add the actual payment processing logic

        return PaymentStatus.Completed;
    }

    public PaymentStatus Refund(string transactionId, decimal amount)
    {
        // Simulate refund processing
        Console.WriteLine($"Refunding payment of {amount:C} for PayPal transactionId {transactionId}");

        return PaymentStatus.Refunded;
    }
}

public class CreditCardProcessor : IPaymentProcessor
{
    public PaymentStatus Charge(IPaymentDetails paymentDetails)
        //(string cardNumber, DateTime expiryDate, string currency, decimal amount)
    {
        CreditCardPaymentDetails creditCardPaymentDetails = paymentDetails as CreditCardPaymentDetails;

        if (creditCardPaymentDetails == null)
        {
            throw new ArgumentException("Invalid payment details for Credit Card processor.");
        }

        // Simulate payment processing
        Console.WriteLine(
            $"Processing payment of {creditCardPaymentDetails.Amount:C}{creditCardPaymentDetails.Currency} for card number {creditCardPaymentDetails.CardNumber}, expires on {creditCardPaymentDetails.ExpiryDate.ToShortDateString()}");
        // Here you would add the actual payment processing logic

        return PaymentStatus.Completed;
    }

    public PaymentStatus Refund(string transactionId, decimal amount)
    {
        // Simulate refund processing
        Console.WriteLine($"Refunding payment of {amount:C} for CreditCard transactionId {transactionId}");
        // Here you would add the actual refund processing logic
        return PaymentStatus.Refunded;
    }
}

public class BankTransferProcessor : IPaymentProcessor
{
    public PaymentStatus Charge(IPaymentDetails paymentDetails)
        //(string cardNumber, DateTime expiryDate, string currency, decimal amount)
    {
        BankPaymentDetails bankPaymentDetails = paymentDetails as BankPaymentDetails;

        if (bankPaymentDetails == null)
        {
            throw new ArgumentException("Invalid payment details for Bank Transfer processor.");
        }

        // Simulate payment processing
        Console.WriteLine(
            $"Processing payment of {bankPaymentDetails.Amount:C}{bankPaymentDetails.Currency} for IBAN {bankPaymentDetails.IBAN}");
        // Here you would add the actual payment processing logic

        return PaymentStatus.Completed;
    }

    public PaymentStatus Refund(string transactionId, decimal amount)
    {
        // Simulate refund processing
        Console.WriteLine($"Refunding payment of {amount:C} for CreditCard transactionId {transactionId}");
        // Here you would add the actual refund processing logic
        return PaymentStatus.Refunded;
    }
}