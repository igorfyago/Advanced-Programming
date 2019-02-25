using System;
using System.Collections.Generic;
using Commerce.LooseCoupling.Interfaces;
using Commerce.LooseCoupling.Model;
using Commerce.TightCoupling.Services;

namespace Commerce.LooseCoupling.Services
{
    public class ReservationService : IReservationService
    {
        public void ReserveInventory(IEnumerable<OrderItem> items)
        {
            foreach (OrderItem item in items)
            {
                try
                {
                    var inventorySystem = new InventorySystem();
                    inventorySystem.Reserve(item.Sku, item.Quantity);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }
    }
}