namespace ProvaPub.Models
{
	public class CustomerListModel : PaginationModel
    {
		public List<CustomerModel> Customers { get; set; }
	}
}
