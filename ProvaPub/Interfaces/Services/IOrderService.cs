using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderModel> PayOrder(PaymentModel paymentModel);
        Task<OrderModel> InsertOrder(OrderModel order);
    }
}
