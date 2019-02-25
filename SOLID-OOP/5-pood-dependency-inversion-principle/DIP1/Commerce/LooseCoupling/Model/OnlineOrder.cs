using Commerce.LooseCoupling.Interfaces;

namespace Commerce.LooseCoupling.Model
{
    public class OnlineOrder : Order
    {
        private readonly INotificationService _notificationService;
        private readonly PaymentDetails _paymentDetails;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReservationService _reservationService;

        public OnlineOrder(Cart cart,
                           PaymentDetails paymentDetails,
                           IPaymentProcessor paymentProcessor,
                           IReservationService reservationService,
                           INotificationService notificationService)
            : base(cart)
        {
            _paymentDetails = paymentDetails;
            _paymentProcessor = paymentProcessor;
            _reservationService = reservationService;
            _notificationService = notificationService;
        }

        public override void Checkout()
        {
            _paymentProcessor.ProcessCreditCard(_paymentDetails, _cart.TotalAmount);

            _reservationService.ReserveInventory(_cart.Items);

            _notificationService.NotifyCustomerOrderCreated(_cart);

            base.Checkout();
        }
    }
}