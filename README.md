# Dependency-inversion-principle

Принцип інверсії залежностей - залежати треба від абстракцій, а не від конкретних реалізацій.

Як працює код:
- Є інтерфейс IPaymentService.
- Є реалізації: PayPalService, CardService.
- Клас Checkout працює з інтерфейсом, а не з конкретним способом оплати.

У Main можна змінити спосіб оплати, передаючи потрібну реалізацію (PayPalService або CardService). Таким чином, Checkout залежить від абстракції, а не від конкретних класів.

## Код
```csharp
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
```

## Результат
![Результат виконання](scr5.png)
