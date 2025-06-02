namespace PaymentsProcessor;

public static class PaymentProcessorFactory
{
    public static IPaymentProcessor GetPaymentProcessor(string paymentType)
    {
        return paymentType switch
        {
            "CreditCard" => new CreditCardProcessor(),
            "PayPal" => new PaypalProcessor(),
            "BankTransfer" => new BankTransferProcessor(),
            _ => throw new NotSupportedException($"Payment type '{paymentType}' is not supported.")
        };
    }
}