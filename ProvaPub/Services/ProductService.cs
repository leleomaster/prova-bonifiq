using ProvaPub.Interfaces.Services;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : IProductService
    {
        TestDbContext _ctx;
        private readonly IListResultService _listResultService;

        public ProductService(TestDbContext ctx, IListResultService listResultService)
        {
            _ctx = ctx;
            _listResultService = listResultService;
        }
              
        public ProductListModel ListProducts(int page)
        {
            List<ProductModel>? products = _ctx.Products.ToList();

            var listModel = from c in products
                            select new ListModel()
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Orders = null
                            };

            var listResul = _listResultService.ListResults(page, listModel.ToList());

            var listCustomerModel = from c in listResul.Orders
                                    select new ProductModel()
                                    {
                                        Id = c.Id,
                                        Name = c.Name
                                    };

            return new ProductListModel() { HasNext = listResul.HasNext, TotalCount = listResul.TotalCount, Products = listCustomerModel.ToList() };
        }
    }
}
