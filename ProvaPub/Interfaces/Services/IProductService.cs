using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services
{
    public interface IProductService
    {
        ProductListModel ListProducts(int page);
    }
}
