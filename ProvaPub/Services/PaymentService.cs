using ProvaPub.Models;

namespace ProvaPub.Services
{
    public abstract class PaymentService
    {
        public abstract Task<bool> PayOrder(PaymentModel paymentModel);
    }
}
