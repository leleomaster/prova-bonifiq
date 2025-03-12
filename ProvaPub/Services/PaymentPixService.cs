using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaymentPixService : PaymentService
    {
        public async override Task<bool> PayOrder(PaymentModel paymentModel)
        {
            //Faz pagamento via pix...
            await Task.CompletedTask;

            return true;
        }
    }
}
