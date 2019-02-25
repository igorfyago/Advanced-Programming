using Commerce.LooseCoupling.Interfaces;
using Commerce.LooseCoupling.Model;

namespace Commerce.LooseCoupling.Fakes
{
    class FakePaymentProcessor : IPaymentProcessor
    {
        public decimal AmountPassed = 0;
        public bool WasCalled = false;
        public void ProcessCreditCard(PaymentDetails paymentDetails, decimal amount)
        {
            WasCalled = true;
            AmountPassed = amount;
        }
    }
}