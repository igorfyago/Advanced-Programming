using System;
using System.Net.Mail;
using Commerce.LooseCoupling.Interfaces;
using Commerce.LooseCoupling.Model;
using Commerce.Utility;

namespace Commerce.LooseCoupling.Services
{
    internal class NotificationService : INotificationService
    {
        public void NotifyCustomerOrderCreated(Cart cart)
        {
            string customerEmail = cart.CustomerEmail;
            if (!String.IsNullOrEmpty(customerEmail))
            {
                using (var message = new MailMessage("orders@somewhere.com", customerEmail))
                using (var client = new SmtpClient("localhost"))
                {
                    message.Subject = "Your order placed on " + DateTime.Now;
                    message.Body = "Your order details: \n " + cart;

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Problem sending notification email", ex);
                        throw;
                    }
                }
            }
        }
    }
}