using System;

namespace Commerce.TightCoupling.Services
{
    public class PaymentGateway : IDisposable
    {
        public string CardNumber { get; set; }
        public string Credentials { get; set; }

        public string ExpiresMonth { get; set; }

        public string ExpiresYear { get; set; }

        public string NameOnCard { get; set; }

        public decimal AmountToCharge { get; set; }

        public void Charge()
        {
            throw new AvsMismatchException();
        }

        public void Dispose()
        {
        }
    }

    public class AvsMismatchException : Exception
    {
    }
}