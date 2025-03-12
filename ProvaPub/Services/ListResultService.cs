using ProvaPub.Interfaces.Services;
using ProvaPub.Models;
using ProvaPub.Repository;
using System.Collections.Generic;

namespace ProvaPub.Services
{
    public class ListResultService : IListResultService
    {
        public ListResultModel ListResults(int page, List<ListModel> listModel)
        {
            var pagination = 10;

           // List<CustomerModel>? customers = _ctx.Customers.ToList();
            var hasNext = true;
            var totalCustomers = 0;
            List<ListModel> listResult = null;

            if (page == 1)
            {
                totalCustomers = listModel.Count();
                hasNext = totalCustomers > pagination;

                listResult = listModel.Take(pagination).ToList();
            }
            else
            {
                hasNext = listModel.Count() > pagination * page;
                listResult = listModel.Skip((pagination * page) - pagination).ToList();
            }

            return new ListResultModel() { HasNext = hasNext, TotalCount = listModel.Count(), Orders = listResult };
        }
    }
}
