namespace ProvaPub.Models
{
    public class PaymentModel
    {
        public PaymentMethod PaymentMethod { get; set; }
        public decimal PaymentValue { get; set; }
        public int CustomerId { get; set; }
    }
}
