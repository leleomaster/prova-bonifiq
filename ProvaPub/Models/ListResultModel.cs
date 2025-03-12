namespace ProvaPub.Models
{
    public class ListResultModel : PaginationModel
    {
        public ICollection<ListModel> Orders { get; set; }
    }
}
