using ProvaPub.Interfaces.Services;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
    {
        TestDbContext _ctx;
        private readonly IPaymentProcessorService _paymentProcessorService;
        private readonly ICustomerService _customerService;

        public OrderService(TestDbContext ctx, IPaymentProcessorService paymentProcessorService, ICustomerService customerService)
        {
            _ctx = ctx;
            _paymentProcessorService = paymentProcessorService;
            _customerService = customerService;
        }


        public async Task<OrderModel> PayOrder(PaymentModel paymentModel)
        {
            var hasPaymentProcessor = await _paymentProcessorService.PayOrder(paymentModel);

            if (hasPaymentProcessor && await _customerService.CanPurchase(paymentModel.CustomerId, paymentModel.PaymentValue))
            {
                return await InsertOrder(new OrderModel() //Retorna o pedido para o controller
                {
                    Value = paymentModel.PaymentValue,
                    OrderDate = DateTime.UtcNow,
                    CustomerId = paymentModel.CustomerId
                });
            }
            else
            {
                return new();
            }
        }

        public async Task<OrderModel> InsertOrder(OrderModel orderModel)
        {
            //Insere pedido no banco de dados
            var order = (await _ctx.Orders.AddAsync(orderModel)).Entity;

            _ctx.SaveChanges();

            order.OrderDate = order.OrderDate.ToLocalTime();

            return order;
        }
    }
}
