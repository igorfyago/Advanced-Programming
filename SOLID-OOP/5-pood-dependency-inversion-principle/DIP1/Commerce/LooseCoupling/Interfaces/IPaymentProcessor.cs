using System;
using Commerce.LooseCoupling.Model;

namespace Commerce.LooseCoupling.Interfaces
{
    public interface IPaymentProcessor
    {
        void ProcessCreditCard(PaymentDetails paymentDetails, decimal amount);
    }
}