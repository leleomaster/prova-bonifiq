using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaymentPayPalService : PaymentService
    {
        public async override Task<bool> PayOrder(PaymentModel paymentModel)
        {
            //Faz pagamento via PayPal...
            await Task.CompletedTask;

            return true;
        }
    }
}
