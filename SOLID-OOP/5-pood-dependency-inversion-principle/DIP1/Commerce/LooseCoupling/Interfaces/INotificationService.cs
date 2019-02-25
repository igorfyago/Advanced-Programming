using System;
using Commerce.LooseCoupling.Model;

namespace Commerce.LooseCoupling.Interfaces
{
    public interface INotificationService
    {
        void NotifyCustomerOrderCreated(Cart cart);
    }
}