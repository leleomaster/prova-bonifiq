namespace ProvaPub.Models
{
    public class ListModel : DefaultPropertiesModel
    {
        public ICollection<OrderModel> Orders { get; set; }
    }
}
