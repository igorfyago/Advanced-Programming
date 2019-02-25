using System;
using System.Net.Mail;
using Commerce.Utility;

namespace Commerce.LooseCoupling.Model

{
    public abstract class Order
    {
        protected readonly Cart _cart;

        protected Order(Cart cart)
        {
            _cart = cart;
        }

        public virtual void Checkout()
        {
            // log the order in the database
        }
    }


    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}