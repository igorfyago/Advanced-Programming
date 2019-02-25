using System;
using System.Collections.Generic;
using Commerce.LooseCoupling.Model;

namespace Commerce.LooseCoupling.Interfaces
{
    public interface IReservationService
    {
        void ReserveInventory(IEnumerable<OrderItem> items);
    }
}