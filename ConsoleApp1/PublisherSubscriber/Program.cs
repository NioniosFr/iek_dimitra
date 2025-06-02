namespace PublisherSubscriber;

// Delegates and Events

/// <summary>
/// type-safe function pointer
/// </summary>
public delegate void PaymentHandler();

public class Payment
{
    // event is a delegate
    public event PaymentHandler PaymentReceived;
    public event PaymentHandler PaymentCancelled;
    public event PaymentHandler PaymentCompleted;

    public void ProcessPayment()
    {
        Console.WriteLine("Payment processed");
        // raise the event
        OnPaymentReceived();
    }

    public void OnPaymentCancelled()
    {
        Console.WriteLine("Payment cancelled");
        // raise the event
        PaymentCancelled?.Invoke();
    }

    public void OnPaymentCompleted()
    {
        Console.WriteLine("Payment completed");
        // raise the event
        PaymentCompleted?.Invoke();
    }

    protected virtual void OnPaymentReceived()
    {
        Console.WriteLine("Payment received");
        PaymentReceived?.Invoke();
    }
}

public class StockUnitsKeeper
{
    public StockUnitsKeeper(Payment payment)
    {
        payment.PaymentCancelled += OnPaymentCancelled;
        payment.PaymentReceived += OnPaymentReceived;
    }

    public void OnPaymentReceived()
    {
        Console.WriteLine("Stock units keeper: Removed 1 unit from stock");
    }

    public void OnPaymentCancelled()
    {
        Console.WriteLine("Stock units keeper: Added 1 unit to stock");
    }
}

public class EmailSender
{
    public EmailSender(Payment payment)
    {
        payment.PaymentCancelled += OnPaymentCancelled;
        payment.PaymentReceived += OnPaymentReceived;
        payment.PaymentCompleted += OnPaymentCompleted;
    }

    public void OnPaymentReceived()
    {
        Console.WriteLine("Email sender: Payment received email sent");
    }

    public void OnPaymentCancelled()
    {
        Console.WriteLine("Email sender: Payment cancelled email sent");
    }

    public void OnPaymentCompleted()
    {
        Console.WriteLine("Email sender: Payment completed email sent");
    }
}

public class TaxCalculator
{
    public TaxCalculator(Payment payment)
    {
        payment.PaymentCancelled += OnPaymentCancelled;
        payment.PaymentReceived += OnPaymentReceived;
        payment.PaymentCompleted += OnPaymentCompleted;
    }

    public void OnPaymentReceived()
    {
        Console.WriteLine("Tax calculator: Calculated tax");
    }

    public void OnPaymentCancelled()
    {
        Console.WriteLine("Tax calculator: Payment cancelled");
    }

    public void OnPaymentCompleted()
    {
        Console.WriteLine("Tax calculator: Payment completed");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var payment = new Payment();
        var stockUnitsKeeper = new StockUnitsKeeper(payment);
        var emailSender = new EmailSender(payment);
        var taxCalculator = new TaxCalculator(payment);

        Console.WriteLine("Simulate process payment");
        payment.ProcessPayment();

        // Simulate payment cancellation and completion
        Console.WriteLine("Simulate payment cancellation and completion");
        payment.OnPaymentCancelled();
        
        
        
        Console.WriteLine("Simulate process completed");
        payment.OnPaymentCompleted();
        
        Console.ReadLine();
    }
}