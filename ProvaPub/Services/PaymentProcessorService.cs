using ProvaPub.Interfaces.Services;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaymentProcessorService : IPaymentProcessorService
    {
        public async Task<bool> PayOrder(PaymentModel paymentModel)
        {
            switch (paymentModel.PaymentMethod)
            {
                case PaymentMethod.pix:
                    var paymentPix = new PaymentPixService();
                    return await paymentPix.PayOrder(paymentModel);

                case PaymentMethod.credicard:

                    var paymentCredicard = new PaymentCredicardService();
                    return await paymentCredicard.PayOrder(paymentModel);

                case PaymentMethod.paypal:

                    var paymentPayPal = new PaymentPayPalService();
                    return await paymentPayPal.PayOrder(paymentModel);

                default: return false;
            }
        }
    }
}
