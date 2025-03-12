using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services
{
    public interface IPaymentProcessorService
    {
        Task<bool> PayOrder(PaymentModel paymentModel);
    }
}
