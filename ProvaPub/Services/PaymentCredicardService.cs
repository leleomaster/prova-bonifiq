using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaymentCredicardService : PaymentService
    {
        public async override Task<bool> PayOrder(PaymentModel paymentModel)
        {
            //Faz pagamento Credicard...
            await Task.CompletedTask;

            return true;
        }
    }
}
