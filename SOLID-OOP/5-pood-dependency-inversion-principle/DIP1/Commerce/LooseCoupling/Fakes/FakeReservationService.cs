using System.Collections.Generic;
using Commerce.LooseCoupling.Interfaces;
using Commerce.LooseCoupling.Model;

namespace Commerce.LooseCoupling.Fakes
{
    class FakeReservationService : IReservationService
    {
        public bool WasCalled = false;
        public void ReserveInventory(IEnumerable<OrderItem> items)
        {
            WasCalled = true;
        }
    }
}