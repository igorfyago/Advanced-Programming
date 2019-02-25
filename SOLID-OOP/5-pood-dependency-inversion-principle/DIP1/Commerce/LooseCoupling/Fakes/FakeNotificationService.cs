using Commerce.LooseCoupling.Interfaces;
using Commerce.LooseCoupling.Model;

namespace Commerce.LooseCoupling.Fakes
{
    class FakeNotificationService : INotificationService
    {
        public bool WasCalled = false;
        public void NotifyCustomerOrderCreated(Cart cart)
        {
            WasCalled = true;
        }
    }
}