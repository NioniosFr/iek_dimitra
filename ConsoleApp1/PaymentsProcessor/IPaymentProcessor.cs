namespace PaymentsProcessor;

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
    Refunded
}

public interface IPaymentDetails
{
    decimal Amount { get; }
    string Currency { get; }
}

public interface IPaymentProcessor
{
    PaymentStatus Charge(IPaymentDetails paymentDetails);
    PaymentStatus Refund(string transactionId, decimal amount);
}
