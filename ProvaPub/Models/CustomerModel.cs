namespace ProvaPub.Models
{
	public class CustomerModel : DefaultPropertiesModel
    {
		public ICollection<OrderModel> Orders { get; set; }
	}
}
