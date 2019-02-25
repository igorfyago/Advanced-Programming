namespace Commerce.LooseCoupling.Model
{
    public enum PaymentMethod
    {
        Cash,
        CreditCard
    }

    public class PaymentDetails
    {
        public PaymentMethod PaymentMethod { get; set; }

        public string CreditCardNumber { get; set; }

        public string ExpiresMonth { get; set; }

        public string ExpiresYear { get; set; }

        public string CardholderName { get; set; }
    }
}