using System;

interface IPaymentService
{
    void Pay(double amount);
}

class PayPalService : IPaymentService
{
    public void Pay(double amount) =>
        Console.WriteLine($"Paid {amount} via PayPal");
}

class CardService : IPaymentService
{
    public void Pay(double amount) =>
        Console.WriteLine($"Paid {amount} via Credit Card");
}

class Checkout
{
    private readonly IPaymentService _paymentService;

    public Checkout(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public void Process(double amount)
    {
        _paymentService.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        IPaymentService paypal = new PayPalService();
        IPaymentService card = new CardService();

        Checkout checkout1 = new Checkout(paypal);
        checkout1.Process(200);

        Checkout checkout2 = new Checkout(card);
        checkout2.Process(500);
    }
}

