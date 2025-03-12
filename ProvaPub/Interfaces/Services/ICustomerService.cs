using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<bool> CanPurchase(int customerId, decimal purchaseValue);
        CustomerListModel ListCustomers(int page);
    }
}
